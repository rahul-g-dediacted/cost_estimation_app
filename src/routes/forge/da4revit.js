const express = require('express');
const { credentials } = require('../../config');
const fs = require('fs');
const {
    ItemsApi,
    VersionsApi,
    BucketsApi,
    ObjectsApi,
    PostBucketsSigned,
    PostBucketsPayload,
} = require('forge-apis');
const {
    getWorkitemStatus,
    cancelWorkitem,
    exportDWF,
    runExteriorInterior,
    workitemList
} = require('./common/da4revit')
const request = require('request')
const { getClient, getInternalToken } = require('../forge/common/oauth');
const SOCKET_TOPIC_WORKITEM = 'Workitem-Notification';
const { v4 : uuidv4 } =require( 'uuid');

let router = express.Router();

/// Middleware for obtaining a token for each request.
router.use(async (req, res, next) => {
    const token = await getInternalToken();
    req.oauth_token = token;
    req.oauth_client = getClient();
    next();
});

//? Cancel the file workitem process if possible.
//! NOTE: This may not successful if the workitem process is already started
router.delete('/da4revit/v1/revit/:workitem_id', async (req, res, next) => {
    const workitemId = req.params.workitem_id;
    try {
        await cancelWorkitem(workitemId, req.oauth_token.access_token);
        let workitemStatus = {
            'WorkitemId': workitemId,
            'Status': "cancelled"
        };

        const workitem = workitemList.find((item) => {
            return item.workitemId === workitemId;
        })
        if (workitem === undefined) {
            console.log('the workitem is not in the list')
            return;
        }
        console.log('The workitem: ' + workitemId + ' is cancelled')
        let index = workitemList.indexOf(workitem);
        workitemList.splice(index, 1);

        global.MyApp.SocketIo.emit(SOCKET_TOPIC_WORKITEM, workitemStatus);
        res.status(204).end();
    } catch (err) {
        res.status(500).end("error");
    }
})
//? Query the status of the workitem
router.get('/da4revit/v1/revit/:workitem_id', async (req, res, next) => {
    const workitemId = req.params.workitem_id;
    try {
        let workitemRes = await getWorkitemStatus(workitemId, req.oauth_token.access_token);
        if(workitemRes.body.status === 'inprogress' || workitemRes.body.status === 'pending' ){
            let workitemStatus = {
                'Status': 'pending',
                'Report': ''
            };
            res.status(200).json(workitemStatus);
            console.log(workitemRes.body)
        }else{
            request.get(workitemRes.body.reportUrl, function (error, response, body) {
                if (!error && response.statusCode == 200) {
                    let workitemStatus = {
                        'Status': workitemRes.body.status.includes('failed') ? "failed" 
                         : workitemRes.body.status === 'success' ? 'completed' : workitemRes.body.status,
                        'Report': body
                    };
                    res.status(200).json(workitemStatus);
                    console.log(workitemRes.body)
                }
            });
        }       
    } catch (err) {
        res.status(500).end("error");
    }
})
// !callback
router.post('/callback/designautomation', async (req, res, next) => {
    // Best practice is to tell immediately that you got the call
    // so return the HTTP call and proceed with the business logic
    res.status(202).end();

    console.log("call back tu forge",req.body)
    console.log("workitemList,",workitemList)
    let workitemStatus = {
        'WorkitemId': req.body.id,
        'Status': "Success",
        'ExtraInfo': null
    };
    if (req.body.status === 'success') {
        const workitem = workitemList.find((item) => {
            return item.workitemId === req.body.id;
        })

        if (workitem === undefined) {
            console.log('The workitem: ' + req.body.id + ' to callback is not in the item list')
            return;
        }
        let index = workitemList.indexOf(workitem);
        workitemStatus.Status = 'completed';
        workitemStatus.ExtraInfo = workitem.outputUrl;

        request.get(req.body.reportUrl, function (error, response, body) {
            if (!error && response.statusCode == 200) {
                workitemStatus.Report = body
                global.MyApp.SocketIo.emit(SOCKET_TOPIC_WORKITEM, workitemStatus);
                // Remove the workitem after it's done
                workitemList.splice(index, 1);
            }
        });
        console.log(req.body);
    } else {
        request.get(req.body.reportUrl, function (error, response, body) {
            if (!error && response.statusCode == 200) {
                workitemStatus.Report = body
                workitemStatus.Status = 'failed';
                global.MyApp.SocketIo.emit(SOCKET_TOPIC_WORKITEM, workitemStatus);
            }
        });
        console.log(req.body);
    }
    return;
})

router.post('/da4revit/v1/revit/check-revit-version', async (req, res, next) => {
    var options = {
        method: 'GET',
        url: `https://developer.api.autodesk.com/oss/v2/buckets/${req.body.bucketKey}/objects/${req.body.objectKey}`,
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            Authorization: `Bearer ${req.oauth_token.access_token}`,
        },
        encoding: null
    }
    request(options, function (error, response, body) {
        console.log(body)
    })
        .on('data', function (chunk) {
            // const tt = Buffer.from(chunk, 'utf8')
            // var buffer =fs.readFileSync(tt)
            const buffer = chunk.toString('utf8',0,10 * 1024)
            if (buffer.includes("A u t o d e s k")) {
                console.log(buffer);
            }
              
        })


})

//? Export Images Casting report
// Export image
router.post('/da4revit/v1/revit/ex-in', async (req, res, next) => {
    const inputJson = req.body.inputJson;
    const inputRvtUrl = req.body.inputRvt;
    const appBundleName = req.body.appBundleName;
    if (inputJson === '' || inputRvtUrl === '' || appBundleName === '') {
        res.status(400).end('make sure the input version id has correct value');
        return;
    }

    const Temp_Output_File_Name = 'imagesbase64.json';
    let inputFileName = Date.now()+'_params.json'
    // create the temp output storage
    let bucketKey = credentials.client_id.toLowerCase() + '_designautomation_test';
    let payload = new PostBucketsPayload();
    payload.bucketKey = bucketKey
    payload.policyKey = 'transient';
    try {
        bucket = await new BucketsApi().createBucket(payload, {}, req.oauth_client, req.oauth_token);
    } catch (err) {
        console.log(err)
    };//! catch the exception while bucket is already there

    try {
        const objectApi = new ObjectsApi();
        const object = await objectApi.uploadObject(bucketKey, Date.now()+'_'+ Temp_Output_File_Name, 0, '', {}, req.oauth_client, req.oauth_token);
        const signedObjOutput = await objectApi.createSignedResource(bucketKey, object.body.objectKey, new PostBucketsSigned(minutesExpiration = 50), { access: 'readwrite' }, req.oauth_client, req.oauth_token)

        let result = await runExteriorInterior(appBundleName, inputRvtUrl, inputJson, signedObjOutput.body.signedUrl, req.oauth_token);
        if (result === null || result.statusCode !== 200) {
            res.status(500).end('failed to export file');
            return;
        }
        
        console.log('Submitted the workitem: ' + result.body.id);
        const exportInfo = {
            "WorkitemId": result.body.id,
            "Status": result.body.status,
            "ExtraInfo": signedObjOutput.body.signedUrl,
            castingReportData
        };

        res.status(200).json(exportInfo);
    } catch (err) {
        request.get(err.reportUrl, function (error, response, body) {
            if (!error && response.statusCode == 200) {
                let workitemStatus = {
                    'Status': "failed",
                    'Report': body
                };
                global.MyApp.SocketIo.emit(SOCKET_TOPIC_WORKITEM, workitemStatus);
                console.log(err)
            }
        });
        res.status(500);
    }
});


module.exports = router;