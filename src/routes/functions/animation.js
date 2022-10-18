const express = require("express");
const _ = require("lodash");
const Axios = require("axios");
const router = express.Router();
const dataBase = require("../../models/modelData");
const costLineModel = require("../../models/costLineModel");
const exInModel = require("../../models/exInModel");
const { workitemList } = require("../forge/common/da4revit");
const request = require("request");
const SOCKET_TOPIC_WORKITEM = "Workitem-Notification";
const { MongoClient } = require("mongodb");

const db = require("../../models");
const { createConnection } = require("mongoose");

//dataBase.deleteMany({}).then((x) => console.log("x", x));

// truin postgres setup
const { Pool } = require('pg');
// const pool = new Pool({
//   host: 'localhost',
//   user: 'postgres',
//   password: 'postgres',
//   database: 'RSMean',
// });
const pool = new Pool({
  host: 'localhost',
  user: 'rv',
  password: '25794',
  database: 'rsmeans',
});

const log = console.log.bind(this);

router.post("/animationData/:projectId", async (req, res, next) => {
  // const data = await dataBase.aggregate([
  //     {
  //         $project: {
  //             model_name: 1,
  //             model_id: 1,
  //             Category: 1,
  //             Location_Line: 1,
  //             Function: 1,
  //             Family: 1,
  //         },
  //     },
  // ]);
  // res.status(200).json(JSON.stringify(data))
  Axios.get("http://localhost:5000/getdf02/" + req.params.projectId)
    .then((resp) => {
      console.log("> Data Retrieved from python service");
      res.status(200).json(resp.data);
    })
    .catch((err) => {
      console.log(err);
    });
});

// Get missing data percentage
router.post("/test/:projectId/:modelId", async (req, res, next) => {
  const weightage = {
    Level: 30,
    Structural_Material: 25,
    Assembly_Code: 15,
    Location_Line: 10,
    Function: 10,
    Length: 5,
    Volume: 5,
  };

  const data = await dataBase.aggregate([
    {
      $match: {
        projectId:{
          $eq: req.params.projectId
        },
        modelId: {
          $eq: req.params.modelId
        }
      }  
    },
    {      
      $facet: {
        missing_rows: [
          {
            $group: {
              _id: null,
              Family: {
                $sum: { $cond: [{ $in: ["$Family", [null, ""]] }, 1, 0] },
              },
              Category: {
                $sum: { $cond: [{ $in: ["$Category", [null, ""]] }, 1, 0] },
              },
              Level: {
                $sum: { $cond: [{ $in: ["$Level", [null, ""]] }, 1, 0] },
              },
              Location_Line: {
                $sum: {
                  $cond: [{ $in: ["$Location_Line", [null, ""]] }, 1, 0],
                },
              },
              Function: {
                $sum: { $cond: [{ $in: ["$Function", [null, ""]] }, 1, 0] },
              },
              Structural_Material: {
                $sum: {
                  $cond: [{ $in: ["$Structural_Material", [null, ""]] }, 1, 0],
                },
              },
              Assembly_Code: {
                $sum: {
                  $cond: [{ $in: ["$Assembly_Code", [null, ""]] }, 1, 0],
                },
              },
              Length: {
                $sum: { $cond: [{ $in: ["$Length", [null, ""]] }, 1, 0] },
              },
              Area: {
                $sum: { $cond: [{ $in: ["$Area", [null, ""]] }, 1, 0] },
              },
              Volume: {
                $sum: { $cond: [{ $in: ["$Volume", [null, ""]] }, 1, 0] },
              },
            },
          },
        ],
        total_rows: [
          {
            $count: "Family",
          },
        ],
      },
    },
  ]);

  if (data[0]["total_rows"].length === 0) {
    console.log("No data retrieved form the database");
    res.status(200).json({ Score: 0 });
    return;
  }
  // console.log(data[0]['missing_rows'])
  // console.log(data[0]['total_rows'][0]['Family'])
  console.log(data[0]["total_rows"]);
  const totalRows = data[0]["total_rows"][0]["Family"];
  const missingRows = data[0]["missing_rows"][0];
  var missingDataJson = {
    Family: ((missingRows["Family"] / totalRows) * 100).toFixed(2),
    Category: ((missingRows["Category"] / totalRows) * 100).toFixed(2),
    Level: ((missingRows["Level"] / totalRows) * 100).toFixed(2),
    Location_Line: ((missingRows["Location_Line"] / totalRows) * 100).toFixed(
      2
    ),
    Function: ((missingRows["Function"] / totalRows) * 100).toFixed(2),
    Structural_Material: (
      (missingRows["Structural_Material"] / totalRows) *
      100
    ).toFixed(2),
    Assembly_Code: ((missingRows["Assembly_Code"] / totalRows) * 100).toFixed(
      2
    ),
    Length: ((missingRows["Length"] / totalRows) * 100).toFixed(2),
    Area: ((missingRows["Area"] / totalRows) * 100).toFixed(2),
    Volume: ((missingRows["Volume"] / totalRows) * 100).toFixed(2),
  };
  const totalMissingPercent = (
    (missingDataJson["Level"] * weightage["Level"] +
      missingDataJson["Structural_Material"] *
        weightage["Structural_Material"] +
      missingDataJson["Assembly_Code"] * weightage["Assembly_Code"] +
      missingDataJson["Location_Line"] * weightage["Location_Line"] +
      missingDataJson["Function"] * weightage["Function"] +
      missingDataJson["Length"] * weightage["Length"] +
      missingDataJson["Volume"] * weightage["Volume"]) /
    100
  ).toFixed(2);
  //missingDataJson['Total Percentage of Missing Data'] = totalMissingPercent
  res.status(200).json({ Score: (100 - totalMissingPercent).toFixed(2) });
});

//get all elements missing assembly code
router.get("/assembly-code/:projectId", async (req, res, next) => {
  console.log(" req.params.projectId", req.params.projectId);
  let datas = await dataBase
    .find({ projectId: req.params.projectId })
    .select("Assembly_Code model_name model_id Family projectId");

  let r = datas.filter(
    (x) => _.isEmpty(x.Assembly_Code) || _.isNil(x.Assembly_Code)
  );

  return res.status(200).json(r);
});

//get all element material
router.get("/material/:projectId/:modelId"/*truin changes*/, async (req, res, next) => {  
  log(
    'costDataFetch',
    req.params.projectId,
    req.params.modelId
  );
  let datas = await dataBase
    .find({ 
      projectId: req.params.projectId,
      modelId: req.params.modelId 
    })
    .select(
      "Structural_Material model_name model_id Family Assembly_Code BaseCosts CostLineId projectId modelId Level Category ML_filled"
    );

  log(
    'costDataFetch',
    'dataFromMongodb',
    datas.length    
  )

  let query = [
    'a-uni-imp-std-2021-q3-us-ms-laurel',
    'cam-uni-imp-std-2021-q3-us-ms-laurel',
    'e-uni-imp-std-2021-q3-us-ms-laurel',
    'i-uni-imp-std-2021-q3-us-ms-laurel',
    'm-uni-imp-std-2021-q3-us-ms-laurel',
    'p-uni-imp-std-2021-q3-us-ms-laurel'
  ]
    
  for(let key of datas){

    let assemblyCode = key.Assembly_Code;    
    let pgData = await pool.query(`SELECT "BaseCosts" FROM public."AssemblyCostLineEntity"
      WHERE "AssemblyCatelogId" IN
      ('${query[0]}','${query[1]}','${query[2]}','${query[3]}','${query[4]}','${query[5]}')
      AND "LineNumber" LIKE '${assemblyCode}%' LIMIT 1`
    );    
    
    if(pgData.rows.length>0){
      let pgDataRow = pgData.rows[0];
      let EquipmentCost = pgDataRow.BaseCosts.EquipmentCost;
      let MaterialCost = pgDataRow.BaseCosts.MaterialCost;
      let LaborCost = pgDataRow.BaseCosts.LaborCost;
      let TotalCost = EquipmentCost + MaterialCost + LaborCost;
      let BaseCosts = {
        EquipmentCost,
        MaterialCost,
        LaborCost,
        TotalCost
      }
      key['BaseCosts'] = BaseCosts;
    }    
  };

  log(
    'costDataFetch',
    'dataFromPostgres',
    datas.length
  )

  return res.status(200).json(datas);
});

router.put("/assembly-code-edit", async (req, res, next) => {
  let ids = req.body.ids;

  try {
    for (let index = 0; index < ids.length; index++) {
      let id = ids[index];

      let r = await dataBase.updateOne(
        { _id: id },
        { $set: { Assembly_Code: req.body.code } }
      );
    }

    return res.status(200).json();
  } catch (error) {
    console.error(error);
    return res.status(400).json("Update Fail");
  }
});

router.put("/material", async (req, res, next) => {
  let ids = req.body.ids;

  try {
    for (let index = 0; index < ids.length; index++) {
      let id = ids[index];

      let r = await dataBase.updateOne(
        { _id: id },
        { $set: { Structural_Material: req.body.material } }
      );
    }

    return res.status(200).json();
  } catch (error) {
    console.error(error);
    return res.status(400).json("Update Fail");
  }
});

router.put("/cost-line-update", async (req, res, next) => {
  let ids = req.body.ids;
  try {
    for (let index = 0; index < ids.length; index++) {
      let id = ids[index];
      let r = await dataBase.updateOne(
        { _id: id },
        {
          $set: {
            BaseCosts: req.body.costData.BaseCosts,
            LineNumber: req.body.costData.LineNumber,
          },
        }
      );
    }

    return res.status(200).json();
  } catch (error) {
    console.error(error);
    return res.status(400).json("Update Fail");
  }
});

router.post("/set-ex-in", async (req, res, next) => {
  let data = req.body;

  console.log("req", req.body);
  let workitemStatus = {
    WorkitemId: req.body.id,
    Status: "Success",
    ExtraInfo: null,
  };

  if (req.body.status === "success") {
    const workitem = workitemList.find((item) => {
      return item.workitemId === req.body.id;
    });

    if (workitem === undefined) {
      console.log(
        "The workitem: " + req.body.id + " to callback is not in the item list"
      );
      return;
    }

    let index = workitemList.indexOf(workitem);
    workitemStatus.Status = "completed";
    workitemStatus.ExtraInfo = workitem.outputUrl;

    request.get(workitem.outputUrl, async function (error, response, body) {
      if (!error && response.statusCode == 200) {
        try {
          let datas = JSON.parse(body);
          let r = await dataBase.updateMany({}, { $set: { Location: -1 } });

          if (Array.isArray(datas.Exs)) {
            for (let index = 0; index < datas.Exs.length; index++) {
              const data = datas.Exs[index];

              let r = await dataBase.updateOne(
                { model_id: data.Id },
                { $set: { Location: 1 } }
              );
            }
          }

          if (Array.isArray(datas.Ins)) {
            for (let index = 0; index < datas.Ins.length; index++) {
              const data = datas.Ins[index];

              let r = await dataBase.updateOne(
                { model_id: data.Id },
                { $set: { Location: 0 } }
              );
            }
          }

          //Update

          if (Array.isArray(datas.EleLevels)) {
            for (let index = 0; index < datas.EleLevels.length; index++) {
              const data = datas.EleLevels[index];

              try {
                let r = await dataBase.updateOne(
                  { model_id: data.Id },
                  { $set: { LevelString: data.Level, Level: data.Level } }
                );
              } catch (error) {
                console.log("errer set level");
              }
            }
          }

          if (Array.isArray(datas.Datas)) {
            for (let index = 0; index < datas.Datas.length; index++) {
              const data = datas.Datas[index];

              try {
                let r = await dataBase.updateOne(
                  { model_id: data.Id },
                  {
                    $set: {
                      Volume: data.Volume,
                      Length: data.Length,
                      Area: data.Area,
                    },
                  }
                );
              } catch (error) {
                console.log("errer set data volume length area");
              }
            }
          }
        } catch (e) {
          console.error("error set ex in");
        }

        workitemStatus.Report = body;
        global.MyApp.SocketIo.emit(SOCKET_TOPIC_WORKITEM, workitemStatus);
        // Remove the workitem after it's done
        workitemList.splice(index, 1);
      }
    });
  }

  try {
    return res.status(200).json();
  } catch (error) {
    console.error(error);
    return res.status(400).json("Update Fail");
  }
});

router.get("/cost-line-by-catalog-id-assembly-code", async (req, res, next) => {  

  let assemblyCode = req.query.assemblyCode;

  let query = [
    'a-uni-imp-std-2021-q3-us-ms-laurel',
    'cam-uni-imp-std-2021-q3-us-ms-laurel',
    'e-uni-imp-std-2021-q3-us-ms-laurel',
    'i-uni-imp-std-2021-q3-us-ms-laurel',
    'm-uni-imp-std-2021-q3-us-ms-laurel',
    'p-uni-imp-std-2021-q3-us-ms-laurel'
  ]
  
  let pgData = await pool.query(`SELECT "BaseCosts" FROM public."AssemblyCostLineEntity"
    WHERE "AssemblyCatelogId" IN
    ('${query[0]}','${query[1]}','${query[2]}','${query[3]}','${query[4]}','${query[5]}')
    AND "LineNumber" LIKE '${assemblyCode}%' LIMIT 1`
  );  

  if(pgData.rows.length===0){
    while(assemblyCode.length>=6){      
      assemblyCode = assemblyCode.slice(0,assemblyCode.length-1);        
      pgData = await pool.query(`SELECT * FROM public."AssemblyCostLineEntity"
        WHERE "AssemblyCatelogId" IN
        ('${query[0]}','${query[1]}','${query[2]}','${query[3]}','${query[4]}','${query[5]}')
        AND "LineNumber" LIKE '${assemblyCode}%'`
      );        
    };
  };

  if(pgData.rows.length>0){    
    pgData = pgData.rows.map((x) => ({
      BaseCosts: x.BaseCosts,
      _id: x.Idd,      
      LineNumber: x.LineNumber,
      Description: x.Description,
      ShortDescription: x.ShortDescription,
    }));
    return res.status(200).json(pgData);
  };
  
  // const client = new MongoClient(process.env.MONGODB_URL2);
  // await client.connect();
  // console.log("assemblyCode", assemblyCode);
  // const db = client.db("Revit");
  // const costLineCollection = db.collection("RSAssemblyCostLine");
  // let items = await costLineCollection
  //   .find({ LineNumber: { $regex: assemblyCode } })
  //   .map((x) => ({
  //     BaseCosts: x.BaseCosts,
  //     _id: x._id,
  //     Id: x.Id,
  //     LineNumber: x.LineNumber,
  //     Description: x.Description,
  //     ShortDescription: x.ShortDescription,
  //   }))
  //   .toArray();
  // console.log("items.count", items.length);
  // if (assemblyCode) {
  //   items = items.filter(x => x.LineNumber.includes(assemblyCode));
  // }  
});

router.post("/project-add", async (req, res, next) => {
  let request = req.body;
  let items = await db.Projects.find({});

  if (items.some((x) => x.ProjectName == request.ProjectName)) {
    return res.status(400).json({
      message: "Project Name already exist !",
    });
  }

  let rs = await db.Projects.create(request);

  return res.status(200).json(rs);
});

router.get("/project-get-all", async (req, res, next) => {
  let items = await db.Projects.find({});

  return res.status(200).json(items);
});

router.put("/project-add-model/:id", async (req, res, next) => {
  let id = req.params.id;
  let request = req.body;
  console.log("res", request);
  let item = await db.Projects.findByIdAndUpdate(
    id,
    {
      $push: {
        Models: request,
      },
    },
    { new: true, useFindAndModify: false }
  );

  return res.status(200).json(item);
});

// export csv
router.get("/exportCSV/:projectId/:modelId/:fileType/:downloadOption", async (req, res, next) => {  

  // modal
  const exportCSV = require('../../models/exportCSV');
  const exportCostData = require('./deps/exportCSV.js'); 
  
  log({
    route:'exportCSV',
    projectId:req.params.projectId,
    modelId:req.params.modelId,
    fileType:req.params.fileType,
    downloadOption:req.params.downloadOption
  });  

  // fetch dynamos
  let data = await exportCSV
    .find({ 
      projectId: req.params.projectId,
      modelId: req.params.modelId 
    });
    
  log({
    route:'exportCSV',
    mongoFetchLength:data.length
  });  

  // Postgres data from mongo and mapping
  let costDataFull = await Promise.all(data.map(async(val)=>{   
    let dat = await pool.query(`SELECT "BaseCosts" FROM public."AssemblyCostLineEntity" 
      WHERE "AssemblyCatelogId" IN ('a-uni-imp-std-2021-q3-us-ms-laurel','cam-uni-imp-std-2021-q3-us-ms-laurel','e-uni-imp-std-2021-q3-us-ms-laurel','i-uni-imp-std-2021-q3-us-ms-laurel','m-uni-imp-std-2021-q3-us-ms-laurel','p-uni-imp-std-2021-q3-us-ms-laurel') AND "LineNumber" LIKE 
      '${val.Assembly_Code}%' LIMIT 1`);    

    if(dat.rows[0]!==undefined){
      let BaseCosts = dat.rows[0].BaseCosts;
      let EquipmentCost = BaseCosts.EquipmentCost != '' ? BaseCosts.EquipmentCost : 0;
      let MaterialCost = BaseCosts.MaterialCost != '' ? BaseCosts.MaterialCost : 0;
      let LaborCost = BaseCosts.LaborCost != '' ? BaseCosts.LaborCost :  0;
      let TotalCost = EquipmentCost+MaterialCost+LaborCost;
      let obj = {
        Category:val.Category||'N/A',
        Name: val.Family||'N/A',
        Material:val.Structural_Material||'N/A',
        Unit:val.Unit_Of_Measure||'N/A',
        Length:val.Length||'N/A',
        Area:val.Area||'N/A',
        Volume:val.Volume||'N/A',
        AssemblyCode: val.Assembly_Code||'N/A',
        EquipmentCost,
        MaterialCost,
        LaborCost,
        TotalCost        
      }
      return obj;
    }
    else{
     let obj = {
        Category:val.Category||'N/A',
        Name: val.Family||'N/A',
        Material:val.Structural_Material||'N/A',           
        Unit:val.Unit_Of_Measure||'N/A',
        Length:val.Length||'N/A',
        Area:val.Area||'N/A',
        Volume:val.Volume||'N/A',
        AssemblyCode: val.Assembly_Code||'N/A',        
        EquipmentCost:0,
        MaterialCost:0,
        LaborCost:0,
        TotalCost:0        
      }
      return obj; 
    }    
  }));  

  log({
    route:'exportCSV',
    costDataFull:costDataFull.length
  });  

  // data ordering and grouping
  let costDataCategoryRaw = _.groupBy(costDataFull, "Category");

  log({
    route:'exportCSV',
    costDataCategoryRaw:Object.keys(costDataCategoryRaw).length
  });


  // cost data category wise
  let costDataCategory = [];
  for(let category in costDataCategoryRaw){
    let totalEquipmentCost = 0;
    let totalMaterialCost = 0;
    let totalLaborCost = 0;     
    let totalCost = 0;
    let quantity = 0;
    costDataCategoryRaw[category].forEach((item)=>{
      if(item.TotalCost!==0){
        totalEquipmentCost+=item.EquipmentCost;
        totalMaterialCost+=item.MaterialCost;
        totalLaborCost+=item.LaborCost;
        totalCost+=item.TotalCost;
      };
      quantity++;
    });
    let obj = {
      category,
      quantity,
      totalEquipmentCost,
      totalMaterialCost,
      totalLaborCost,
      totalCost    
    };
    costDataCategory.push(obj);
  };

  log({
    route:'exportCSV',
    costDataCategory:costDataCategory.length
  }); 

  log(costDataCategory);
  return

  // total cost data
  let totalEquipmentCost = 0;
  let totalMaterialCost = 0;
  let totalLaborCost = 0;     
  let totalCost = 0;
  for(let category in costDataCategory){
    totalEquipmentCost+=costDataCategory[category].totalEquipmentCost;
    totalMaterialCost+=costDataCategory[category].totalMaterialCost;
    totalLaborCost+=costDataCategory[category].totalLaborCost;
    totalCost+=costDataCategory[category].totalCost;    
  };
  let costDataTotal = {
    totalEquipmentCost,
    totalMaterialCost,
    totalLaborCost,
    totalCost
  };  

  log({
    route:'exportCSV',
    costDataTotal
  });  

  if(req.params.fileType==='excel'){
    // excel deps
    const ExcelJS = require('exceljs');    
    const workbook = new ExcelJS.Workbook();    

    const sheetTotal = workbook.addWorksheet('Total Cost Data');
    sheetTotal.columns = exportCostData.totalColumns;
    sheetTotal.addRow(costDataTotal);

    log({
      route:'exportCSV',
      excelStatus:'totalRowsAdded'
    })

    res.setHeader('Content-Type', 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet');
    res.setHeader("Content-Disposition", "attachment; filename=fileName.xlsx");

    if(req.params.downloadOption==='full'){
      const sheetUnit = workbook.addWorksheet('Cost Data By Units');
      sheetUnit.columns = exportCostData.allColumns;
      sheetUnit.addRows(costDataFull);

      log({
        route:'exportCSV',
        excelStatus:'allRowsAdded'
      })

      const data = await workbook.xlsx.writeBuffer();
  
      res.send(data);      

      res.end();
    }
    else if (req.params.downloadOption==='category'){
      const sheetCategory = workbook.addWorksheet('Cost Data By Category');
      sheetCategory.columns = exportCostData.categoryColumns;
      sheetCategory.addRows(costDataCategory);

      log({
        route:'exportCSV',
        excelStatus:'categoryRowsAdded'
      })

      const data = await workbook.xlsx.writeBuffer();
  
      res.send(data);
            
    }
  }

  else if (req.params.fileType==='pdf'){
    res.setHeader('Content-Type', 'application/pdf');
    res.setHeader("Content-Disposition", "attachment; filename=fileName.pdf");

    const PDFDocument = require('pdfkit-table');
    
    const tableTotal = { 
      title: 'Total Cost Data',
      headers: exportCostData.pdfTotalColumns,
      rows: [
        [
          costDataTotal.totalEquipmentCost,
          costDataTotal.totalMaterialCost,
          costDataTotal.totalLaborCost,
          costDataTotal.totalCost
        ]
      ]
    }

    if(req.params.downloadOption==='category'){
      const doc = new PDFDocument({ margin: 30, size: 'A4' });

      doc.pipe(res);

      doc.table(tableTotal);

      log({
        route:'exportCSV',
        status:'tableTotalCreated'
      });

      const tableCategory = {
        title: 'Total Cost By Category',
        headers: exportCostData.pdfCategoryColumns,
        datas: costDataCategory
      }
  
      doc.table(tableCategory);

      log({
        route:'exportCSV',
        status:'tableCategoryCreated'
      });

      doc.end();
    } 
    else if (req.params.downloadOption==='full'){
      const doc = new PDFDocument({ margin: 10, size: 'A0' });

      doc.pipe(res);      

      doc.table(tableTotal,{width:500});

      log({
        route:'exportCSV',
        status:'tableTotalCreated'
      });      

      const tableFull = {
        title: 'Total Cost By Units',
        headers: exportCostData.pdfFullColumns,
        datas: costDataFull
      }
  
      doc.table(tableFull);

      log({
        route:'exportCSV',
        status:'tableFullCreated'
      });

      doc.end();
    }
    else {
      return
    }    
  }

})

module.exports = router;
