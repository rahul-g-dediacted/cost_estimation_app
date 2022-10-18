const request = require('request');

const { designAutomation } = require('../../../config');

var workitemList = [];

// ?get status
function getWorkitemStatus(workItemId, access_token) {
  return new Promise(function (resolve, reject) {
    var options = {
      method: 'GET',
      url: designAutomation.endpoint + 'workitems/' + workItemId,
      headers: {
        Authorization: 'Bearer ' + access_token,
        'Content-Type': 'application/json',
      },
    };

    request(options, function (error, response, body) {
      if (error) {
        reject(err);
      } else {
        let resp;
        try {
          resp = JSON.parse(body);
        } catch (e) {
          resp = body;
        }
        if (response.statusCode >= 400) {
          console.log(
            'error code: ' +
              response.statusCode +
              ' response message: ' +
              response.statusMessage
          );
          reject({
            statusCode: response.statusCode,
            statusMessage: response.statusMessage,
          });
        } else {
          resolve({
            statusCode: response.statusCode,
            headers: response.headers,
            body: resp,
          });
        }
      }
    });
  });
}
// !cancel workitem
function cancelWorkitem(workItemId, access_token) {
  return new Promise(function (resolve, reject) {
    var options = {
      method: 'DELETE',
      url: designAutomation.endpoint + 'workitems/' + workItemId,
      headers: {
        Authorization: 'Bearer ' + access_token,
        'Content-Type': 'application/json',
      },
    };

    request(options, function (error, response, body) {
      if (error) {
        reject(err);
      } else {
        let resp;
        try {
          resp = JSON.parse(body);
        } catch (e) {
          resp = body;
        }
        if (response.statusCode >= 400) {
          console.log(
            'error code: ' +
              response.statusCode +
              ' response message: ' +
              response.statusMessage
          );
          reject({
            statusCode: response.statusCode,
            statusMessage: response.statusMessage,
          });
        } else {
          resolve({
            statusCode: response.statusCode,
            headers: response.headers,
            body: resp,
          });
        }
      }
    });
  });
}

//export images for casting report
function runExteriorInterior(
  appBundleName,
  inputRvtUrl,
  inputJson,
  outputJsonUrl,
  access_token_2Legged
) {
  console.log('appBundleName', appBundleName);
  return new Promise(function (resolve, reject) {
    let webHook = designAutomation.webhook_url.replace(
      'forge/callback/designautomation',
      'function/animation/set-ex-in'
    );
     
    const workitemBody = {
      activityId:
        designAutomation.nickname +
        '.' +
        appBundleName +
        '+' +
        designAutomation.appbundle_activity_alias,
      arguments: {
        inputFile: {
          url: inputRvtUrl,
          Headers: {
            Authorization: 'Bearer ' + access_token_2Legged.access_token,
          },
        },
        inputJson: {
          url: 'data:application/json,' + JSON.stringify('[]'),
          Headers: {
            Authorization: 'Bearer ' + access_token_2Legged.access_token,
          },
        },
        outputJson: {
          verb: 'put',
          url: outputJsonUrl,
          Headers: {
            Authorization: 'Bearer ' + access_token_2Legged.access_token,
          },
        },
        // onProgress: {
        //   verb: "put",
        //   url: 'https://webhook.site/1a1e7d83-3273-4f58-9f23-34ea2d2e3a63',
        //   ondemand: true,
        // },
        onComplete: {
          verb: 'post',
          url: webHook,
        },
      },
    };

    var options = {
      method: 'POST',
      url: designAutomation.endpoint + 'workitems',
      headers: {
        Authorization: 'Bearer ' + access_token_2Legged.access_token,
        'Content-Type': 'application/json',
      },
      body: workitemBody,
      json: true,
    };

    request(options, function (error, response, body) {
      if (error) {
        console.error('loi roi , ', error);
        reject(error);
      } else {
        let resp;
        try {
          resp = JSON.parse(body);
        } catch (e) {
          resp = body;
        }
        workitemList.push({
          workitemId: resp.id,
          createVersionData: null,
          access_token_3Legged: null,
          outputUrl: outputJsonUrl,
        });

        console.error(response.body);
        if (response.statusCode >= 400) {
          reject({
            statusCode: response.statusCode,
            statusMessage: response.statusMessage,
          });
        } else {
          resolve({
            statusCode: response.statusCode,
            headers: response.headers,
            body: resp,
          });
        }
      }
    });
  });
}

module.exports = {
  getWorkitemStatus,
  cancelWorkitem,
  runExteriorInterior,
  workitemList,
};
