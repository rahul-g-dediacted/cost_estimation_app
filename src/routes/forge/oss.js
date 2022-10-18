const fs = require("fs");
const express = require("express");
const multer = require("multer");
const { v4: uuidv4 } = require("uuid");
const { BucketsApi, ObjectsApi, PostBucketsPayload } = require("forge-apis");

const db = require("../../models");

const { getClient, getInternalToken } = require("./common/oauth");
const config = require("../../config");
const eachLimit = require("async/eachLimit");
let router = express.Router();

// Middleware for obtaining a token for each request.
router.use(async (req, res, next) => {
  const token = await getInternalToken();
  req.oauth_token = token;
  req.oauth_client = getClient();
  next();
});

// POST /api/forge/oss/objects - uploads new object to given bucket.
// Request body must be structured as 'form-data' dictionary
// with the uploaded file under "fileToUpload" key, and the bucket name under "bucketKey".
router.post(
  "/objects/:id",
  multer({ dest: "uploads/" }).single("fileToUpload"),
  async (req, res, next) => {
    fs.readFile(req.file.path, async (err, data) => {
      if (err) {
        next(err);
      }
      console.log("req", req.params.id);
      let id = req.params.id;
      try {
        let payload = new PostBucketsPayload();
        payload.bucketKey =
          config.credentials.client_id.toLowerCase() + "_dynamo_bucket";
        payload.policyKey = "persistent"; //'transient'; // expires in 24h
        try {
          await new BucketsApi().createBucket(
            payload,
            {},
            req.oauth_client,
            req.oauth_token
          );
        } catch (err) {
          console.log("err bucket exist", err);
        }

        let object = await uploadFile(
          payload.bucketKey,
          req.file,
          data,
          req.oauth_client,
          req.oauth_token
        );

        object = {
          ...object,
          modelName: req.file.originalname,
          isHasMetadata: false,
        };

        await fs.unlinkSync(req.file.path);
        await addModel(id, object);

        global.MyApp.SocketIo.emit("realtime-upload", {
          ...object,
          id: object.id,
          text: object.text,
        });

        return res.status(200).json(object);
      } catch (err) {
        console.log("err", err);
        await fs.unlinkSync(req.file.path);
        res.status(400).end();
      }
    });
  }
);

async function addModel(id, request) {
  await db.Projects.findByIdAndUpdate(
    id,
    {
      $push: {
        Models: request,
      },
    },
    { new: true, useFindAndModify: false }
  );
}

const uploadFile = async (bucketKey, file, data, oauth_client, oauth_token) => {
  if (data.length < 100 * 1024 * 1024) {
    try {
      let response = await new ObjectsApi().uploadObject(
        bucketKey,
        uuidv4() + file.originalname,
        data.length,
        data,
        {},
        oauth_client,
        oauth_token
      );
      if (response) {
        return {
          ...response.body,
          id: Buffer.from(response.body.objectId).toString("base64"),
          text: response.body.objectKey,
        };
      } else {
        return {
          id: "",
          text: "",
        };
      }
    } catch (err) {
      console.log(err);
      return {
        id: "",
        text: "",
      };
    }
  } else {
    const opts = {
      chunkSize: 5 * 1024 * 1024,
      concurrentUploads: 5,
    };
    try {
      var temp = await uploadObjectChunked(
        file.path,
        bucketKey,
        uuidv4() + file.originalname,
        data,
        opts
      );
      let response = await new ObjectsApi().getObjectDetails(
        temp.bucketKey,
        temp.objectKey,
        {},
        oauth_client,
        oauth_token
      );

      if (response) {
        return {
          ...response.body,
          id: Buffer.from(response.body.objectId).toString("base64"),
          text: response.body.objectKey,
        };
      } else {
        return {
          id: "",
          text: "",
        };
      }
    } catch (err) {
      console.log(err);
      return {
        id: "",
        text: "",
      };
    }
  }
};

uploadObjectChunked = (path, bucketKey, objectKey, data, opts = {}) => {
  return new Promise((resolve, reject) => {
    const chunkSize = opts.chunkSize || 5 * 1024 * 1024;

    const nbChunks = Math.ceil(data.length / chunkSize);

    const chunksMap = Array.from(
      {
        length: nbChunks,
      },
      (e, i) => i
    );

    // generates uniques session ID
    const sessionId = guid();

    // prepare the upload tasks
    const uploadTasks = chunksMap.map((chunkIdx) => {
      const start = chunkIdx * chunkSize;

      const end = Math.min(data.length, (chunkIdx + 1) * chunkSize) - 1;

      const range = `bytes ${start}-${end}/${data.length}`;

      const length = end - start + 1;

      const readStream = fs.createReadStream(path, {
        start,
        end,
      });

      const run = async () => {
        const token = await getInternalToken();
        const credentials = getClient();
        return await new ObjectsApi().uploadChunk(
          bucketKey,
          objectKey,
          length,
          range,
          sessionId,
          readStream,
          {},
          { autoRefresh: false },
          token,
          credentials
        );
      };

      return {
        chunkIndex: chunkIdx,
        run,
      };
    });

    let progress = 0;

    eachLimit(
      uploadTasks,
      opts.concurrentUploads || 3,
      (task, callback) => {
        task.run().then(
          (res) => {
            callback();
          },
          (err) => {
            console.log(err);
            callback(err);
          }
        );
      },
      (err) => {
        if (err) {
          return reject(err);
        }
        return resolve({
          fileSize: data.length,
          bucketKey,
          objectKey,
          nbChunks,
        });
      }
    );
  });
};

function guid(format = "xxxxxxxxxxxx") {
  var d = new Date().getTime();

  return format.replace(/[xy]/g, function (c) {
    var r = (d + Math.random() * 16) % 16 | 0;
    d = Math.floor(d / 16);
    return (c == "x" ? r : (r & 0x7) | 0x8).toString(16);
  });
}

// GET /api/forge/oss/buckets - expects a query param 'id'; if the param is '#' or empty,
// returns a JSON with list of buckets, otherwise returns a JSON with list of objects in bucket with given name.
router.get("/buckets", async (req, res, next) => {
  const bucket_name = req.query.id;
  if (!bucket_name || bucket_name === "#") {
    try {
      const buckets = await new BucketsApi().getBuckets(
        { limit: 100 },
        req.oauth_client,
        req.oauth_token
      );
      res.json(
        buckets.body.items.map((bucket) => {
          return {
            id: bucket.bucketKey,
            // Remove bucket key prefix that was added during bucket creation
            text: bucket.bucketKey.replace(
              config.credentials.client_id.toLowerCase() + "-",
              ""
            ),
            type: "bucket",
            children: true,
          };
        })
      );
    } catch (err) {
      next(err);
    }
  } else {
    try {
      // Retrieve up to 100 objects from Forge using the [ObjectsApi](https://github.com/Autodesk-Forge/forge-api-nodejs-client/blob/master/docs/ObjectsApi.md#getObjects)
      // Note: if there's more objects in the bucket, you should call the getObjects method in a loop, providing different 'startAt' params
      const objects = await new ObjectsApi().getObjects(
        bucket_name,
        { limit: 100 },
        req.oauth_client,
        req.oauth_token
      );
      res.json(
        objects.body.items.map((object) => {
          return {
            id: Buffer.from(object.objectId).toString("base64"),
            text: object.objectKey,
            type: "object",
            children: false,
          };
        })
      );
    } catch (err) {
      next(err);
    }
  }
});

// POST /api/forge/oss/objects - uploads new object to given bucket.
// Request body must be structured as 'form-data' dictionary
// with the uploaded file under "fileToUpload" key, and the bucket name under "bucketKey".
router.post(
  "/objects",
  multer({ dest: "uploads/" }).single("fileToUpload"),
  async (req, res, next) => {
    fs.readFile(req.file.path, async (err, data) => {
      if (err) {
        next(err);
      }
      try {
        // Upload an object to bucket using [ObjectsApi](https://github.com/Autodesk-Forge/forge-api-nodejs-client/blob/master/docs/ObjectsApi.md#uploadObject).
        await new ObjectsApi().uploadObject(
          req.body.bucketKey,
          req.file.originalname,
          data.length,
          data,
          {},
          req.oauth_client,
          req.oauth_token
        );
        res.status(200).end();
      } catch (err) {
        next(err);
      }
    });
  }
);

module.exports = router;
