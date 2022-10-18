# Intelligent Construction

Forge viewer with reactjs and RSMeans API

### _Frontend Client built using react js_

Below are some of the predefined endpoints for the code to display revit files

- http://localhost:3000/viewer/dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6NTFkenZ0YXcyempiaGlvNWpzeXNvdXlrM3RnamFpcHhfZHluYW1vX2J1Y2tldC8xNDg1MjE5NTYwLnJ2dA==
- http://localhost:3000/viewer/dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6NTFkenZ0YXcyempiaGlvNWpzeXNvdXlrM3RnamFpcHhfZHluYW1vX2J1Y2tldC9keW5hbW9fYXR0cmFjdEluZm9tYXRpb25fdjEucnZ0
- http://localhost:3000/viewer/dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6NTFkenZ0YXcyempiaGlvNWpzeXNvdXlrM3RnamFpcHhfZHluYW1vX2J1Y2tldC9yc3RfYWR2YW5jZWRfc2FtcGxlX3Byb2plY3QucnZ0

http://localhost:3000/viewer/dXJuOmFkc2sub2JqZWN0czpvcy5vYmplY3Q6eXgweGV4cjdqdmM2emQ2cXYydWZhcTBhbThpMXUydDdfZHluYW1vX2J1Y2tldC9BcGFydG1lbnQucnZ0
**Note** : Use the above endpoints only after running the server.

### _Backend Server built using node js_

_Backend Service Endpoints_

- Authenticate with forge : **_/api/forge/oauth_**
- Get Animation data (gets data from flask server): **_/api/function/animation/animationData_**
- Get data from flask server
  - data as csv : **_/api/services/python/getdatacsv_**
  - schedule data as csv : **_/api/services/python/getschedulecsv_**

### _Backend communication with Flask service_

For some services the node js backend communicates with a Flask Server to retrieve the required data. below are the flask endpoints for the application.

_Flask Service Endpoints_

- Get animation data : **_FLASK_SERVICE_URL/getdf02_**
- Get Data as csv : **_FLASK_SERVICE_URL/getdf02csv_**
- Get Schedule data as csv : **_FLASK_SERVICE_URL/getschedulecsv_**

**Note**: replace the _FLASK_SERVICE_URL_ with flask service endpoint

### _Steps to run the code on local machine_

- rename .env-example to .env and fill all the details in the .env file.

- Install all the npm Dependencies

  `npm install`

- Install all client Dependencies

  `npm run client-install`

- Start the application (both client and server)

  `npm run dev`

- _Starting python flask server_

  **_Note_**: python 3.9 must be installed and running

  `pip install requirements.txt`

  `python webservice.py`


std   standard union
opn   open shop
fmr  facility management & repair
res  residential
rr  repair & remodelling
fed  federal
he   hign education