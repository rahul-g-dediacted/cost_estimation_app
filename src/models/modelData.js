const mongoose = require('mongoose');

let objModel = {
  centroids_distance_list: {
    type: Array,
    require: true,
  },
  coordinate: {
    type: Object,
    require: true,
  },
  model_id: {
    type: String,
    require: true,
  },
  model_name: {
    type: String,
    require: true,
  },
  Family: {
    type: String,
    require: true,
  },
};

const dataScheme = new mongoose.Schema({
  entroids_distance_list: {
    type: Array,
    require: true,
  },
  coordinate: {
    type: Object,
    require: true,
  },
  model_id: {
    type: String,
    require: true,
  },
  modelId: {
    type: String,
    require: true,
  },
  Category: {
    type: String,
    require: true,
  },
  Assembly_Code: {
    type: String,
    require: false,
  },
  Structural_Material: {
    type: String,
    require: false,
  },
  LevelString: {
    type: String,
    require: false,
  },
  Level: {
    type: String,
    require: false,
  },

  Location: {
    type: String,
    require: false,
  },
  BaseCosts: {
    type: Object,
    require: false,
  },
  CostLineId: {
    type: String,
    require: false,
  },
  MF_number: [Number],
});

module.exports = dataBase = mongoose.model('Dynamo', dataScheme);
