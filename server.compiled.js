"use strict";

var path = require('path');

var express = require('express');

var bodyParser = require('body-parser');

var oauth = require('./src/routes/forge/oauth');

var oss = require('./src/routes/forge/oss');

var modelderivative = require('./src/routes/forge/modelderivative');

var animation = require('./src/routes/functions/animation');

var oldCode = require('./src/routes/functions/oldCode');

var pythonRouter = require('./src/routes/services/pythonService');

var cors = require('cors');

var dotenv = require('dotenv');

var Promise = require("bluebird");

var mongoose = require('mongoose');

var PORT = process.env.PORT || 8080;
var app = express();
app.use(cors());
dotenv.config();
app.use(bodyParser.json({
  limit: '250mb'
}));
mongoose.Promise = Promise;
mongoose.connect(process.env.MONGODB_URL, {
  useCreateIndex: true,
  useNewUrlParser: true,
  useFindAndModify: false,
  useUnifiedTopology: true
}).then(function () {
  return console.log('Connection to MONGODB successful');
})["catch"](function (err) {
  return console.error(err, 'Error');
});
app.use('/api/forge/oauth', oauth);
app.use('/api/function/oldcode', oldCode);
app.use('/api/function/animation', animation);
app.use('/api/forge/oss', oss);
app.use('/api/forge/modelderivative', modelderivative);
app.use('/api/services/python', pythonRouter);
app.use(express["static"](path.join(__dirname, 'client', 'build')));

if (process.env.NODE_ENV === 'production') {
  app.get('*', function (req, res) {
    res.sendFile(path.join(__dirname + '/client/build/index.html'));
  });
} else {
  app.get('*', function (req, res) {
    res.sendFile(path.join(__dirname + '/client/public/index.html'));
  });
}

var server = app.listen(PORT, function () {
  console.log("Server listening on port ".concat(PORT));
});

var io = require('socket.io').listen(server);

global.MyApp = {
  SocketIo: io
};
io.on('connection', function (socket) {});
server.timeout = 60 * 10 * 1000;
