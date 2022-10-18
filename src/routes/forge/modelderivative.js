const express = require("express");
const {
  DerivativesApi,
  JobPayload,
  JobPayloadInput,
  JobPayloadOutput,
  JobSvfOutputPayload,
} = require("forge-apis");
const _ = require("lodash");
const { getClient, getInternalToken } = require("./common/oauth");

let router = express.Router();

// Middleware for obtaining a token for each request.
router.use(async (req, res, next) => {
  const token = await getInternalToken();
  req.oauth_token = token;
  req.oauth_client = getClient();
  next();
});

// POST /api/forge/modelderivative/jobs - submits a new translation job for given object URN.
// Request body must be a valid JSON in the form of { "objectName": "<translated-object-urn>" }.
router.post("/jobs", async (req, res, next) => {
  console.log("req.body.objectName from jobs", req.body.objectName);
  let job = new JobPayload();
  job.input = new JobPayloadInput();
  job.input.urn = req.body.objectName;
  job.output = new JobPayloadOutput([new JobSvfOutputPayload()]);
  job.output.formats[0].type = "svf";
  job.output.formats[0].views = ["2d", "3d"];
  try {
    // Submit a translation job using [DerivativesApi](https://github.com/Autodesk-Forge/forge-api-nodejs-client/blob/master/docs/DerivativesApi.md#translate).
    await new DerivativesApi().translate(
      job,
      { xAdsForce: false },
      req.oauth_client,
      req.oauth_token
    );
    res.status(200).end();
    let progress = 0;
    var manifest = "";
    do {
      manifest = await new DerivativesApi().getManifest(
        req.body.objectName,
        {},
        req.oauth_client,
        req.oauth_token
      );
      var reg = manifest.body.progress.split("%");
      progress = isNumber(reg[0]) ? parseInt(reg[0]) : 100;
      global.MyApp.SocketIo.emit("realtime-translate-process", {
        progress,
      });
    } while (progress < 100);
    console.log("> Translation complete");

    console.log("req.body.objectName return socket", req.body.objectName);
    global.MyApp.SocketIo.emit("realtime-translate", {
      urn: req.body.objectName,
    });
  } catch (err) {
    res.status(400).end();
  }
});
function isNumber(input) {
  try {
    var sas = parseInt(input);
    if (sas.toString() === "NaN") return false;
    else return true;
  } catch {
    return false;
  }
}
module.exports = router;
