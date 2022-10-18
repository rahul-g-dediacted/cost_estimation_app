const mongoose = require('mongoose');


let costLineScheme = {
  MeasurementSystem: {
    type: Number,
    require: false,
  },

};

module.exports = costLineModel = mongoose.model('RSAssemblyCostLine', costLineScheme);

