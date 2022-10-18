const express = require('express');
const Axios = require("axios");
const dotenv = require('dotenv');
dotenv.config();

const pythonRouter = express.Router();

pythonRouter.route('/getdatacsv')
.get((req,res, next)=>{
    Axios.get(process.env.PYTHON_SERVICE_URL+"/getdf02csv")
    .then(resp => {
      console.log("> Data Retrieved from python service for /getdf02csv");
      res.setHeader('Content-Type', resp.headers["content-type"]);
      res.setHeader('content-length', resp.headers["content-length"])
      res.setHeader('content-disposition', resp.headers["content-disposition"])
      res.status(200).send(resp.data);
    })
    .catch(err => {
      console.log(err)
      res.status(500).json({"error": "Error while retrieveing data from python service /getdf02csv"});
    })
})
.post(async (req, res, next) => {
    res.statusCode = 403;
    res.end('POST operation is not supported on /getdatacsv');  
})

pythonRouter.route('/getschedulecsv')
.get((req,res, next)=>{
    Axios.get(process.env.PYTHON_SERVICE_URL+"/getschedulecsv")
    .then(resp => {
      console.log("> Data Retrieved from python service /getschedulecsv");
      res.setHeader('Content-Type', resp.headers["content-type"]);
      res.setHeader('content-length', resp.headers["content-length"])
      res.setHeader('content-disposition', resp.headers["content-disposition"])
      res.status(200).send(resp.data);
    })
    .catch(err => {
      console.log(err)
      res.status(500).json({"error": "Error while retrieveing data from python service /getschedulecsv"});
    })
})
.post(async (req, res, next) => {
    res.statusCode = 403;
    res.end('POST operation is not supported on /getschedulecsv');  
})

pythonRouter.route('/getmissingcsv')
.get((req,res, next)=>{
    Axios.get(process.env.PYTHON_SERVICE_URL+"/getmissingdatacsv")
    .then(resp => {
      console.log("> Data Retrieved from python service /getmissingdatacsv");
      res.setHeader('Content-Type', resp.headers["content-type"]);
      res.setHeader('content-length', resp.headers["content-length"])
      res.setHeader('content-disposition', resp.headers["content-disposition"])
      res.status(200).send(resp.data);
    })
    .catch(err => {
      console.log(err)
      res.status(500).json({"error": "Error while retrieveing data from python service /getmissingdatacsv"});
    })
})
.post(async (req, res, next) => {
    res.statusCode = 403;
    res.end('POST operation is not supported on /getmissingdatacsv');  
})

module.exports = pythonRouter
