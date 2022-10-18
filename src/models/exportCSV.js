//truin export CSV model
const mongoose = require('mongoose');

const exportCSVSchema = new mongoose.Schema({
  modelId:{
    type:String
  },
  Category:{
    type:String
  },
  Family:{
    type: String,
  },
  Structural_Material:{
    type:String
  },
  Unit_Of_Measure:{
    type:String
  },
  Length:{
    type:Number
  }, 
  Area:{
    type:Number
  }, 
  Volume:{
    type:Number
  },
  Assembly_Code:{
    type:String
  }    
});

module.exports = exportCSV = mongoose.model("exportCSV", exportCSVSchema,'dynamos');