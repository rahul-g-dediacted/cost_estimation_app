const express = require('express');
const fs = require('fs');
const { designAutomation }= require('../../config');
const{
    uploadAppBundleAsync,
    apiClientCallAsync    
} = require ('./common/daconfigure')

const { getClient, getInternalToken } = require('../forge/common/oauth');

let router = express.Router();

const APP_BUNDLE_FOLDER= __dirname+'/bundles/';



///////////////////////////////////////////////////////////////////////
/// Middleware for obtaining a token for each request.
///////////////////////////////////////////////////////////////////////
router.use(async (req, res, next) => {
    const token = await getInternalToken();
    req.oauth_token = token;
    req.oauth_client = getClient();
    next();
});

//? Query the list of the engines
router.get('/designautomation/engines-old', async(req, res, next) => {
    try {
        let workitemRes = await apiClientCallAsync( 'GET',  designAutomation.URL.GET_ENGINES_URL, req.oauth_token.access_token);
        const engineList = workitemRes.body.data.filter( (engine ) => {
            return (engine.indexOf('Revit') >= 0)
        })
        res.status(200).json(engineList);
    } catch (err) {
        res.status(500).end("error");
    }
})

router.get('/designautomation/engines', async (req, res, next) => {
    try {
      let Allengines = [];
      let paginationToken = null;
  
      while (true) {
        let url = paginationToken
          ? `${designAutomation.URL.GET_ENGINES_URL}?page=${paginationToken}`
          : designAutomation.URL.GET_ENGINES_URL;

          console.log("req",req.oauth_token)
        let enginesResult = await apiClientCallAsync(
          'GET',
          url,
          req.oauth_token.access_token
        );
        let engines = enginesResult.body;
        Allengines = Allengines.concat(engines.data);
  
        if (engines.paginationToken == null) break;
  
        paginationToken = engines.paginationToken;
      }
  
      const engineList = Allengines.filter((engine) => {
        return engine.indexOf('Revit') >= 0;
      }).sort();
      res.status(200).end(JSON.stringify(engineList));
    } catch (err) {
      res.status(500).end('error');
    }
  });


//? Query the list of the activities
router.get('/designautomation/activities', async(req, res, next) => {
    try {
        const activitiesRes = await apiClientCallAsync( 'GET',  designAutomation.URL.ACTIVITIES_URL, req.oauth_token.access_token);
        res.status(200).json(activitiesRes.body.data);
    } catch (err) {
        res.status(500).end("error");
    }
})
//? Query the list of the appbundle packages
router.get('/appbundles', async(req, res, next) => {
    try {
        const fileArray = fs.readdirSync(APP_BUNDLE_FOLDER);
        const zipFile = fileArray.filter( fileName => {
            return (fileName.indexOf('.zip') >= 0)
        })    
        res.status(200).json(zipFile);
    } catch (err) {
        res.status(500).end("Failed to find appbundle package");
    }
})

//? Delete appbundle from Desigan Automation server
router.delete('/designautomation/appbundles/:appbundle_name', async(req, res, next) =>{
    const appbundle_name = req.params.appbundle_name;
    try {
        await apiClientCallAsync( 'DELETE',  designAutomation.URL.APPBUNDLE_URL + appbundle_name, req.oauth_token.access_token );
        res.status(204).end("AppBundle is deleted");
    } catch (err) {
        res.status(500).end("Failed to delete AppBundle: " + appbundle_name);
    }
})
//? Delete activity from design automation server
router.delete('/designautomation/activities/:activity_name', async(req, res, next) =>{
    const activity_name = req.params.activity_name;
    try {
        await apiClientCallAsync( 'DELETE',  designAutomation.URL.ACTIVITY_URL+activity_name, req.oauth_token.access_token );
        res.status(204).end("Activity is deleted");
    } catch (err) {
        res.status(500).end("Failed to delete activity: " + activity_name );
    }
})
//! Create|Update Appbundle version
router.post('/designautomation/appbundles', async( req, res, next) => {
    const fileName = req.body.fileName;
    const engineName  = req.body.engine;

    const zipFileName = fileName + '.zip';
    const appBundleName = fileName + 'AppBundle';

    // check if ZIP with bundle is existing
    const localAppPath = APP_BUNDLE_FOLDER + zipFileName;
    if (!fs.existsSync(localAppPath)) {
        res.status(400).end(localAppPath + " is not existing");
        return;
    }

    // get defined app bundles
    let appBundles = null;    
    try {
        const appBundlesRes = await apiClientCallAsync( 'GET', designAutomation.URL.APPBUNDLES_URL, req.oauth_token.access_token);
        if( appBundlesRes.body && appBundlesRes.body.data ){
            appBundles = appBundlesRes.body.data;
        }
    } catch (err) {
        console.log("Failed to get the AppBundles");
        res.status(400).end("Failed to get the AppBundles");
        return;
    }

    const qualifiedAppBundleId = designAutomation.nickname + '.' + appBundleName + '+' + designAutomation.appbundle_activity_alias;
    console.log("qualifiedAppBundleId",qualifiedAppBundleId)
    var newAppVersion = null;
    if( appBundles.includes( qualifiedAppBundleId ) ){
        try{
            const appBundleSpec = {
                "Engine" : engineName,
                "Description" : "Export DWF",
            }
            const createAppVersionUrl =  designAutomation.URL.CREATE_APPBUNDLE_VERSION_URL+appBundleName +'/versions';
            newAppVersion = await apiClientCallAsync( 'POST', createAppVersionUrl, req.oauth_token.access_token, appBundleSpec );
            const aliasSpec = {
                "Version" : newAppVersion.body.version
            }
            const modifyAppAliasUrl = designAutomation.URL.UPDATE_APPBUNDLE_ALIAS_URL+appBundleName+'/aliases/'+designAutomation.appbundle_activity_alias;
            await apiClientCallAsync( 'PATCH', modifyAppAliasUrl, req.oauth_token.access_token, aliasSpec );
        }
        catch( err ){
            console.log(err);
            res.status(400).end("Failed to Create AppBundle new version.");
            return;
        }
    }else{
        try{
            const appBundleSpec = {
                "Engine" : engineName,
                "Id" : appBundleName,
                "Description" : 'Export DWF',
            }
            newAppVersion = await apiClientCallAsync( 'POST', designAutomation.URL.APPBUNDLES_URL, req.oauth_token.access_token, appBundleSpec );
            const aliasSpec = {
                "Id" : designAutomation.appbundle_activity_alias,
                "Version" : 1
            }
            const createAppBundleAliasUrl = designAutomation.URL.CREATE_APPBUNDLE_ALIAS_URL+appBundleName+'/aliases';
            await apiClientCallAsync( 'POST', createAppBundleAliasUrl, req.oauth_token.access_token, aliasSpec );
        }
        catch( err ){
            console.log(err);
            res.status(400).end("Failed to create new version of AppBundle.");
            return;
        }
    }
    const contents = fs.readFileSync(localAppPath);
    try{
        await uploadAppBundleAsync(newAppVersion.body.uploadParameters, contents);
        const result = {
            AppBundle : qualifiedAppBundleId,
            Version   : newAppVersion.body.version
        }
        res.status(200).json(result);    
    }catch(err){
        console.log(err);
        res.status(500).end("Failed to upload the package to the url.");
    }
    return;
})
//! Get activity
router.get('/designautomation/list-activities', async( req, res, next) => {
    let activities = null;
    try {
        var temp =[]
        const activityRes = await apiClientCallAsync( 'GET',  designAutomation.URL.ACTIVITIES_URL, req.oauth_token.access_token);
        if(activityRes.body && activityRes.body.data ){
            activities = activityRes.body.data;
        }
        activities.forEach(item =>{
            if(item.includes(designAutomation.nickname))
                if(!item.includes('$LATEST')){
                    let fileName = item.split('.')[1];
                    fileName = fileName.split('+')[0];
                    temp.push(fileName)
                }
         
        })
        res.status(200).json(temp).end()
    } catch (err) {
        res.status(400).end("Failed to get activities.");
    }
})

//! Create activity
router.post('/designautomation/activities', async( req, res, next) => {
    const fileName = req.body.fileName;
    const engineName  = req.body.engine;

    const appBundleName = fileName + 'AppBundle';
    const activityName = fileName + 'Activity';

    if(appBundleName.includes("ExIn")){
       await postCastingReportActivity(req, res)
       return;
    }

    let activities = null;
    try {
        const activityRes = await apiClientCallAsync( 'GET',  designAutomation.URL.ACTIVITIES_URL, req.oauth_token.access_token);
        if(activityRes.body && activityRes.body.data ){
            activities = activityRes.body.data;
        }
    } catch (err) {
        console.log(err);
        res.status(400).end("Failed to get activities.");
        return;
    }
    const qualifiedAppBundleId = designAutomation.nickname + '.' + appBundleName + '+' + designAutomation.appbundle_activity_alias;
    const qualifiedActivityId  = designAutomation.nickname + '.' + activityName + '+' + designAutomation.appbundle_activity_alias;
    if( !activities.includes( qualifiedActivityId ) ){
        const activitySpec = {
            Id : activityName,
            Appbundles : [ qualifiedAppBundleId ],
            'CommandLine' : [ "$(engine.path)\\\\revitcoreconsole.exe /al \"$(appbundles[" + appBundleName + "].path)\"" ],
            Engine : engineName,
            Parameters :
            {
                inputFile: {
                    verb: "get",
                    description: "input file",
                    required: true,
                    localName: "revit.rvt"
                },
                inputJson: {
                    verb: "get",
                    description: "input Json parameters",
                    localName: "params.json"
                },
                outputDwf: {
                    verb: "put",
                    description: "output Dwf file",
                    localName: "result.dwf"
                },              
            }
        }
        try{
            newActivity = await apiClientCallAsync( 'POST',  designAutomation.URL.ACTIVITIES_URL, req.oauth_token.access_token, activitySpec );
            const aliasSpec = {
                "Id" : designAutomation.appbundle_activity_alias,
                "Version" : 1
            }
            const createActivityAliasUrl = designAutomation.URL.CREATE_ACTIVITY_ALIAS+activityName+'/aliases';
            await apiClientCallAsync( 'POST',  createActivityAliasUrl, req.oauth_token.access_token, aliasSpec );
        }catch(err){
            console.log(err);
            res.status(400).end("Failed to create activity");
            return; 
        }
        const activityRes = {
            Activity : qualifiedActivityId,
            Status : "Created"
        }
        res.status(200).end(JSON.stringify(activityRes));
        return;
    }
    const activityRes = {
        Activity : qualifiedActivityId,
        Status : "Existing"
    }
    res.status(200).end(JSON.stringify(activityRes));
    return;
})

//! Create activity Export Images Casting Report
router.post('/designautomation/activities/casting-report',postCastingReportActivity)

async function postCastingReportActivity( req, res) {
    const fileName = req.body.fileName;
    const engineName  = req.body.engine;

    const appBundleName = fileName + 'AppBundle';
    const activityName = fileName + 'Activity';

    let activities = null;
    try {
        const activityRes = await apiClientCallAsync( 'GET',  designAutomation.URL.ACTIVITIES_URL, req.oauth_token.access_token);
        if(activityRes.body && activityRes.body.data ){
            activities = activityRes.body.data;
        }
    } catch (err) {
        console.log(err);
        res.status(400).end("Failed to get activities.");
        return;
    }
    const qualifiedAppBundleId = designAutomation.nickname + '.' + appBundleName + '+' + designAutomation.appbundle_activity_alias;
    const qualifiedActivityId  = designAutomation.nickname + '.' + activityName + '+' + designAutomation.appbundle_activity_alias;
    if( !activities.includes( qualifiedActivityId ) ){
        const activitySpec = {
            Id : activityName,
            Appbundles : [ qualifiedAppBundleId ],
            CommandLine: [
                '$(engine.path)\\\\revitcoreconsole.exe  /al "$(appbundles[' +
                  appBundleName +
                  '].path)"',
              ],
            Engine : engineName,
            Parameters :
            {
                inputFile: {
                    verb: "get",
                    description: "input file",
                    required: true,
                    localName: "revit.rvt"
                },
                inputJson: {
                    verb: "get",
                    description: "input Json parameters",
                    localName: "params.json"
                },
                outputJson: {
                    verb: "put",
                    description: "output json",
                    localName: "output.json"
                },              
            }
        }
        try{
            newActivity = await apiClientCallAsync( 'POST',  designAutomation.URL.ACTIVITIES_URL, req.oauth_token.access_token, activitySpec );
            const aliasSpec = {
                "Id" : designAutomation.appbundle_activity_alias,
                "Version" : 1
            }
            const createActivityAliasUrl = designAutomation.URL.CREATE_ACTIVITY_ALIAS+activityName+'/aliases';
            await apiClientCallAsync( 'POST',  createActivityAliasUrl, req.oauth_token.access_token, aliasSpec );
        }catch(err){
            console.log(err);
            res.status(400).end("Failed to create activity");
            return; 
        }
        const activityRes = {
            Activity : qualifiedActivityId,
            Status : "Created"
        }
        res.status(200).end(JSON.stringify(activityRes));
        return;
    }
    const activityRes = {
        Activity : qualifiedActivityId,
        Status : "Existing"
    }
    res.status(200).end(JSON.stringify(activityRes));
    return;
}

module.exports = router;