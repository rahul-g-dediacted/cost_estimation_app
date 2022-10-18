const path = require('path');
const express = require('express')
const bodyParser = require('body-parser');

const oauth = require('./src/routes/forge/oauth')
const oss = require('./src/routes/forge/oss')
const modelderivative = require('./src/routes/forge/modelderivative')
const animation = require('./src/routes/functions/animation')
const oldCode = require('./src/routes/functions/oldCode')
const pythonRouter = require('./src/routes/services/pythonService')
const da4revit = require('./src/routes/forge/da4revit')
const daconfigure = require('./src/routes/forge/daconfigure')

const cors = require('cors');
const dotenv = require('dotenv');
const Promise = require("bluebird");
const mongoose = require('mongoose');
const PORT = process.env.PORT || 8080;


let app = express();
app.use(cors());
dotenv.config();

app.use(bodyParser.json({ limit: '250mb' }));

mongoose.Promise = Promise
mongoose.connect(process.env.MONGODB_URL, {
  useCreateIndex: true,
  useNewUrlParser: true,
  useFindAndModify: false,
  useUnifiedTopology: true,
})
  .then(() =>
    console.log('Connection to MONGODB successful'))
    
  .catch((err) =>
    console.error(err, 'Error'));

app.use('/api/forge/oauth', oauth);
app.use('/api/function/oldcode', oldCode);
app.use('/api/function/animation', animation);
app.use('/api/forge/oss', oss);
app.use('/api/forge/modelderivative', modelderivative);
app.use('/api/services/python', pythonRouter);
app.use('/api/forge', da4revit);
app.use("/api/forge", daconfigure);
app.use(express.static(path.join(__dirname, 'client', 'build')));

if (process.env.NODE_ENV === 'production') {
  app.get('*', (req, res) => {
    res.sendFile(path.join(__dirname + '/client/build/index.html'));
  })
} else {
  app.get('*', (req, res) => {
    res.sendFile(path.join(__dirname + '/client/public/index.html'));
  })
}

var server = app.listen(PORT, () => { console.log(`Server listening on port ${PORT}`) });
var io = require('socket.io').listen(server);
global.MyApp = {
  SocketIo: io
};

io.on('connection', function (socket) {

})
server.timeout = 60 * 10 * 1000