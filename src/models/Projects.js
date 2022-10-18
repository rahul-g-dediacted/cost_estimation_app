const mongoose = require("mongoose");

const Projects = mongoose.model(
  "Projects",
  new mongoose.Schema(
    {
      ProjectName: {
        type: String,
        require: true,
      },
      LarborType: {
        type: String,
        require: true,
      },
      ProjectType: {
        type: String,
        require: true,
      },
      ZipCode: {
        type: String,
        require: false,
      },
      Models: [],
    },
    { collection: "Projects" }
  )
);

module.exports = Projects;
