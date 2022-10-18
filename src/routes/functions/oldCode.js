const express = require('express');
const router = express.Router();
const dataBase = require('../../models/modelData');
const fs = require('fs');
const db = require('../../models');

router.post('/clearDataOld', async (req, res) => {
  console.log('req.body', req.body);
  try {
    // await dataBase.collection.deleteMany();
    res.status(200).send('success');
  } catch {
    res.status(400).end();
  }
});

router.post('/checkDuplicates', async (req, res) => {
  console.log('req.body', req.body);
  try {
    // const docs = await db.collection.countDocuments({projectId: req.body.projectId});
    // if (docs <= 0){
    //   res.status(200).send("success "+docs);
    // }
    let project = await db.Projects.findOne({ _id: req.body.projectId });

    let model = project.Models.find((x) => x.objectKey == req.body.modelId);
    if (model && model.isHasMetadata) {
      return res.status(400).end();
    }

    return res.status(200).send('success ');
  } catch (e) {
    console.log('e', e);
    res.status(400).end();
  }
});

router.post('/updateDataBase', async (req, res) => {
  try {
    let data = req.body.data;
    data = data.map((x) => ({
      ...x,
      projectId: req.body.projectId,
      modelId: req.body.modelId,
    }));

    let currentProject = await db.Projects.findById(req.body.projectId);

    let models = currentProject.Models.map((x) => ({
      ...x,
      isHasMetadata: x.objectKey == req.body.modelId,
    }));

    let r = await db.Projects.updateOne(
      { _id: req.body.projectId },
      { $set: { Models: models } }
    );

    if (data.length === 0) {
      res.status(200).send('success');
      global.MyApp.SocketIo.emit('realtime-upload-db', {});
    } else {
      res.status(200).send('success');
      let newData = data.map((x) => ({
        ...x,
        ML_filled: 0,
        MF_number: [],
      }));

      console.log('newDAta', newData);

      await dataBase.collection.insertMany(newData);

      // socket call when dynamos is loaded
      global.MyApp.SocketIo.emit('realtime-upload-db', {});
    }
  } catch (err) {
    console.log(err);
    res.status(400).end();
  }
});

router.post('/download', (req, res) => {
  //downloadTxt(req, res);
});
// const downloadTxt = (req, res) => {
//     try {
//         const data = req.body.data;
//         const model_ids = data.map((d) => d.model_id).toString();
//         const model_names = data.map((d) => d.model_name).toString();
//         const number_of_models = data.length.toString();

//         let distances = [];
//         data.forEach((d) => {
//             d.results.forEach((r) => {
//                 //find in from
//                 const matchFrom = distances.find(
//                     (f) => f.from === r.from && f.to === r.to
//                 );
//                 const matchTo = distances.find(
//                     (f) => f.from === r.to && f.to === r.from
//                 );

//                 if (!matchFrom && !matchTo) distances = [...distances, r];
//             });
//         });
//         const centroids_distance_list = distances.map((d) => d.distance).toString();

//         fs.writeFile("download/model_id.txt", model_ids, function (err) {
//             fs.writeFile("download/model_name.txt", model_names, function (err) {
//                 fs.writeFile(
//                     "download/number_of_models.txt",
//                     number_of_models,
//                     function (err) {
//                         fs.writeFile(
//                             "download/centroids_distance_list.txt",
//                             centroids_distance_list,
//                             function (err) {
//                                 res.setHeader("Content-Type", "application/json");
//                                 res.setHeader("Content-Disposition", `model_id`);
//                                 res.zip([
//                                     { path: "./download/model_id.txt", name: "model_id.txt" },
//                                     { path: "./download/model_name.txt", name: "model_name.txt" },
//                                     {
//                                         path: "./download/number_of_models.txt",
//                                         name: "number_of_models.txt",
//                                     },
//                                     {
//                                         path: "./download/centroids_distance_list.txt",
//                                         name: "centroids_distance_list.txt",
//                                     },
//                                 ]);
//                             }
//                         );
//                     }
//                 );
//             });
//         });
//     } catch (error) {
//         console.log(error);
//         res.status(500).end();
//     }
// };

module.exports = router;
