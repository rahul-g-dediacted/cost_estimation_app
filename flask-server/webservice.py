from flask import Flask, jsonify
from flask_cors import CORS
from io import BytesIO
from flask import send_file
import pandas as pd
import numpy as np
import zipfile
import time
from pymongo import MongoClient, ASCENDING
import datetime

app = Flask(__name__)
CORS(app)

def getMissingDataMongo():
    client = MongoClient("mongodb+srv://feahm:eagle999@cluster0.izbcb.mongodb.net/Revit?retryWrites=true&w=majority")
    db = client["Revit"]["dynamos"]
    filter={
        '$or': [
            {'Family': {'$in': [None, '']}}, 
            {'Category': {'$in': [None, '']}},
            {'Level': {'$in': [None, '']}},
            {'Location_Line': {'$in': [None, '']}},
            {'Function': {'$in': [None, '']}},
            {'Structural_Material': {'$in': [None, '']}},
            {'Assembly_Code': {'$in': [None, '']}},
            {'Length': {'$in': [None, '']}},
            {'Area': {'$in': [None, '']}},
            {'Volume': {'$in': [None, '']}}
        ]
    }
    project={
        '_id': 0, 
        'model_name': 1, 
        'model_id': 1, 
        'Family': 1, 
        'Category': 1, 
        'Level': 1, 
        'Location_Line': 1, 
        'Length': 1, 
        'Area': 1, 
        'Volume': 1, 
        'Function': 1, 
        'Structural_Material': 1, 
        'Assembly_Code': 1
    }
    result = db.find(
        filter=filter,
        projection=project
    )
    db_docs = list(result)
    client.close()
    print('> Documents retireved: ',len(db_docs))
    # convert into retrieved records into dataframe
    df01 = pd.DataFrame(db_docs)
    #df01 = df01[list(df01.columns)[1::]] # ignore object_id
    print('> Data frame df01 created with ',len(df01),' rows')
    return df01

def getDatafromMongo():
    print("> Called from Autodesk UI ")
    client = MongoClient("mongodb+srv://feahm:eagle999@cluster0.izbcb.mongodb.net/Revit?retryWrites=true&w=majority")
    db = client["Revit"]["dynamos"]
    # colNames to be displayed
    colNames = {
        'model_name': 1,
        'model_id': 1, 
        'Category': 1, 
        'Location_Line': 1, 
        'Phase_Created':1,
        'Function': 1, 
        'Family': 1,
        'Level': 1,
        'coordinate': 1,
        'Assembly_Code': 1,
        '_id': 0
    }
    pipe = [
        {'$project': colNames},
        {'$sort': {'Assembly_Code': 1}}
    ]
    result = db.aggregate(pipe, allowDiskUse = True)
    db_docs = list(result)
    client.close()
    print('> Documents retireved: ',len(db_docs))
    # convert into retrieved records into dataframe
    df01 = pd.DataFrame(db_docs)
    #df01 = df01[list(df01.columns)[1::]] # ignore object_id
    print('Data frame df01 created with ',len(df01),' rows')
    coordDF = pd.json_normalize(df01['coordinate'])

    df01['z-height'] = coordDF['z']
    print('minimum value: ',min(df01['z-height']))
    print('maximum value: ',max(df01['z-height']))

    levels = 0
    dataRange = 0
    if min(df01['z-height']) < 0:
        levelsAbove0 = np.arange(1,1+max(df01['z-height'])/2)
        levelsBelow0 = np.arange(round(-1+min(df01['z-height'])/2,0),0)
        levels = np.append(levelsBelow0,levelsAbove0)
        # dataRange = np.arange(round(-1+min(df01['z-height']),0),2.0+max(df01['z-height']),2)
        dataRange = np.arange(2*min(levelsBelow0), 2*max(levelsAbove0)+1, 2)
    else:
        levels = np.arange(1,1+max(df01['z-height'])/2)
        dataRange = np.arange(0,2*max(levels)+1,2)
        #dataRange = np.arange(-1,1.0+max(df01['z-height']),2)

    print('No of levels',len(levels))
    print('Range of data',len(dataRange))

    dfCut = pd.cut(df01['z-height'], dataRange, labels=levels)
    df01['level_group'] = dfCut
    df01 = df01.sort_values(['z-height','level_group']) 
    df02 = df01.sort_values(['level_group','Assembly_Code'])
    return (df01,df02,levels)

@app.route('/getdf02', methods=['GET'])
def getDatadf02():
    print('retrieveing data in JSON')
    _, df02, _ = getDatafromMongo()
    return jsonify(df02.to_json(orient='records'))

@app.route('/getdf02csv/<projectId>', methods=['GET'])
def getDatadf02csv(projectId):
    print('retrieveing data in CSV' +projectId)
    _, df02, _ = getDatafromMongo()
    df02Stream = BytesIO(df02.to_csv().encode())
    return send_file(
        df02Stream,
        mimetype="text/csv",
        attachment_filename="data02.csv",
        as_attachment=True
    )

@app.route('/downloaddata',  methods=['GET'])
def downloadData():
    print('retrieveing data in ZIP')
    df01, df02, _ = getDatafromMongo()
    # Return response as Stream
    response_stream = BytesIO()
    with zipfile.ZipFile(response_stream, 'w') as zf:
        zf.writestr('df01data.csv', df01.to_csv())
        zf.writestr('df02Data.csv', df02.to_csv())
    response_stream.seek(0)

    return send_file(
        response_stream,
        mimetype="zip",
        attachment_filename="data.zip",
        as_attachment=True
    )

@app.route('/getschedulecsv',methods=['GET'])
def getSchedule():
    _,df02,levels = getDatafromMongo()
    sch = df02[['Location_Line','model_name','Phase_Created','model_id','level_group']]
    sch.columns = ['Outline_level','Task_Name','Task_Type','Revit_id','level_group']
    sch = sch.reset_index()
    sch = sch[list(sch.columns)[1::]]
    sch['Task_Mode'] = 'Manually Scheduled'
    sch['Active'] = 'Yes'
    sch['Duration (Days)'] = '1'

    print('number of levels: ',len(levels))
    startdateslist = pd.date_range(datetime.datetime.now().replace(hour=8,minute=0,second=0,microsecond=0), periods=len(levels), freq="D")
    enddateslist = pd.date_range(datetime.datetime.now().replace(hour=17,minute=0,second=0,microsecond=0), periods=len(levels), freq="D")
    
    startdatesmap = dict(zip(levels,startdateslist))
    enddatesmap = dict(zip(levels, enddateslist))

    sch['Planned_Start_Date'] = sch['level_group'].map(startdatesmap)
    sch['Planned_Start_Date'] = sch['Planned_Start_Date'].astype('datetime64[ns]')
    sch['Planned_End_Date'] = sch['level_group'].map(enddatesmap)
    sch['Planned_End_Date'] = sch['Planned_End_Date'].astype('datetime64[ns]')
    sch = sch[['Active', 'Task_Mode', 'Task_Name', 'Duration (Days)', 'Planned_Start_Date', 'Planned_End_Date', 'Outline_level', 'Task_Type', 'level_group', 'Revit_id']]

    dataStream = BytesIO(sch.to_csv(date_format='%Y-%m-%d %H:%M:%S').encode())
    return send_file(
        dataStream,
        mimetype="text/csv",
        attachment_filename="schedule.csv",
        as_attachment=True
    )


@app.route('/getmissingdatacsv',methods=['GET'])
def getMissingData():
    print("> Retrieving missing data from the database - Started")
    data = getMissingDataMongo()
    dataStream = BytesIO(data.to_csv(index=False, encoding='utf-8').encode())
    print("> Retrieved missing data from the database - Completed")
    return send_file(
        dataStream,
        mimetype="text/csv",
        attachment_filename="missing_data.csv",
        as_attachment=True
    )

@app.route('/')
def sample():
 return "Prediction3D - Intelligent Construction - Flask API" 

if __name__ == '__main__':
    app.run()
