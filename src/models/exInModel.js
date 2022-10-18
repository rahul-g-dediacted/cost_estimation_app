const mongoose = require('mongoose');

const dataScheme = new mongoose.Schema(
  {
    Id: {
      type: Number,
      require: false,
    },
    Name: {
      type: String,
      require: false,
    },
    Height: {
      type: Number,
      require: false,
    },
    Category: {
      type: String,
      require: false,
    },
  },
);

module.exports = exInModel = mongoose.model('Exterior', dataScheme);
