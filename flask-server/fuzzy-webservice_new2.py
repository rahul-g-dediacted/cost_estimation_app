from copy import Error
from flask import Flask, jsonify
from flask_cors import CORS
from io import BytesIO
from flask import send_file
import pandas as pd
import numpy as np
import zipfile
import time
from pymongo import MongoClient, ASCENDING, UpdateOne, UpdateMany
import datetime

import re
import difflib

app = Flask(__name__)
CORS(app)

def jaccardSimilarity(word, possibilities):
    result = []
    for p in possibilities:
        common = len(set(word.lower().replace(",","").replace(".","").split(" ")).intersection(set(p.lower().replace(",","").replace(".","").split(" "))))
        if common > 0:
            result.append(p)
    return result

def nGramMatching(keyword, possibilities):
    
    result = [" ", -1]
    set_a = []
    keyword = re.sub('\s+', ' ', keyword)
    for i in range(len(keyword)-2):
        set_a.append(keyword.lower()[i:i+3])
    
    set_a = set(set_a)
        
    for p in possibilities:
        set_b = []
        p = re.sub('\s+', ' ', p)
        for i in range(len(p)-2):
            set_b.append(p.lower()[i:i+3])
        set_b = set(set_b)
        
        if len(set_a.intersection(set_b)) > result[1]:
            result[0] = p
            result[1] = len(set_a.intersection(set_b))
    
    return result

def fillMissingValues(missing_dataframe):
    
    filled_assembly_code = []
    filled_mf_numbers = []
    print("> Filling Missing Values")
    # missing_dataframe = pd.read_csv(missingFilePath)
    # missing_dataframe = missing_dataframe.fillna(" ")

    missing_dataframe['Category'] = missing_dataframe['Category'].fillna(" ")
    missing_dataframe['Function'] = missing_dataframe['Function'].fillna(" ")
    
    missing_dataframe["keyword"] = missing_dataframe["Category"]+ " " + missing_dataframe["Function"]
    
    assembly_codes = pd.read_csv("Master_file.csv", usecols=["Name", "Assembly Code", "MF_Number"], encoding="unicode_escape")
    assembly_codes = assembly_codes[~assembly_codes["Name"].isna()]
    assembly_codes = assembly_codes[~assembly_codes["Assembly Code"].isna()]
    print("Number of Codes = ", assembly_codes.shape[0])
    
    for value in missing_dataframe[["keyword", "Assembly_Code"]].values:
        keyword = value[0].replace("  ","").replace("'","")
        if value[1] in ["", " ", np.NaN, np.nan, "NaN", "nan"]:            
           
            n_gram_matching = False
            
            if n_gram_matching is False:
                result = jaccardSimilarity(keyword, assembly_codes["Name"].values.tolist())
                result = difflib.get_close_matches(keyword, result, n=3, cutoff=0.2)
                #print(keyword, result)
            else:
                result = nGramMatching(keyword, assembly_codes["Name"].values.tolist())
                #print(keyword, result)
                
            if result != []:
                a_code = str(assembly_codes[assembly_codes["Name"] == result[0]]["Assembly Code"].values[0])
                a_code = a_code.replace(".", "")+"0" if len(a_code.replace(".", "")) == 5 else a_code.replace(".", "")
                filled_assembly_code.append(str(a_code))
                
                # MF Number
                mf_code = str(assembly_codes[assembly_codes["Name"] == result[0]]["MF_Number"].values[0])
                filled_mf_numbers.append(str(mf_code))
                
            else:
                filled_assembly_code.append("")
                filled_mf_numbers.append("")
    
        else:
            if len(value[1]) < 6:
                assembly_codes['SubStr'] = assembly_codes['Assembly Code'].str[:len(value[1])]
                temp_df = assembly_codes[assembly_codes["SubStr"] == value[1]]
                res = nGramMatching(keyword, temp_df["Name"].values.tolist())
                a_code = str(temp_df[temp_df["Name"] == res[0]]["Assembly Code"].values[0])
                a_code = a_code.replace(".", "")+"0" if len(a_code.replace(".", "")) == 5 else a_code.replace(".", "")
                filled_assembly_code.append(str(a_code))
                print(value[1], keyword,res, a_code)
                
                # MF Number
                mf_code = str(assembly_codes[assembly_codes["Name"] == res[0]]["MF_Number"].values[0])
                filled_mf_numbers.append(str(mf_code))
                
            else:
                filled_assembly_code.append(value[1])
                filled_mf_numbers.append(" ")
            
    missing_dataframe["Assembly_Code"] = filled_assembly_code
    missing_dataframe["MF_Number"] = filled_mf_numbers
    # missing_dataframe.to_csv("experiment_filled.csv", index=False)
    return missing_dataframe
    
# Get missing assembly codes modelID
def getAssemblyCodesList(projectId,modelId):
    client = MongoClient("mongodb+srv://feahm:eagle999@cluster0.izbcb.mongodb.net/Revit?retryWrites=true&w=majority")
    db = client["Revit"]["dynamos"]
    filter={'Assembly_Code': {'$in': [None, ' ', '', '-']},'projectId': {'$eq': projectId}, 'modelId': {'$eq': modelId}}
    project={
        '_id': 0,
        'model_id': 1, 
    }

    result = db.find(
        filter=filter,
        projection=project
    )
    db_docs = list(result)
    client.close()
    print('> Documents retrieved: ',len(db_docs))
    if len(db_docs) < 1:
        return []
    df_asmCodes = pd.DataFrame(db_docs)
    asmCodes_list = df_asmCodes['model_id'].to_list()
    return asmCodes_list

# update DB
def bulkUpdateDB(udpate_df):
    client = MongoClient("mongodb+srv://feahm:eagle999@cluster0.izbcb.mongodb.net/Revit?retryWrites=true&w=majority")
    db = client["Revit"]["dynamos"]
    updates = []
    try:
        for _, row in udpate_df.iterrows():
            updates.append(UpdateMany({'model_id': row.get('model_id')}, {'$set': {'Assembly_Code': row.get('Assembly_Code'), 'ML_filled' : 1}}, upsert=True))
        db.bulk_write(updates)
        client.close()
        print("!!! SUCCESS !!!, success updating the Mongo DB")
        return True
    except Error:
        print("!!! EXCEPTION !!!, Failed updating the Mongo DB")
        print(Error)
        client.close()
        return False

def getMissingDataMongo(projectId):
    client = MongoClient("mongodb+srv://feahm:eagle999@cluster0.izbcb.mongodb.net/Revit?retryWrites=true&w=majority")
    db = client["Revit"]["dynamos"]
    filter={
           "$and": [
        {      '$or': [
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
        ] },
        { "$or": [ { "projectId": projectId } ] }
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
    print('> Documents retrieved: ',len(db_docs))
    # convert into retrieved records into dataframe
    df01 = pd.DataFrame(db_docs)
    #df01 = df01[list(df01.columns)[1::]] # ignore object_id
    print('> Data frame df01 created with ',len(df01),' rows')
    return df01

def getDatafromMongo(projectId,modelId,updateDB=False):
    print("> Called from Autodesk UI " +projectId + modelId)
    client = MongoClient("mongodb+srv://feahm:eagle999@cluster0.izbcb.mongodb.net/Revit?retryWrites=true&w=majority")
    db = client["Revit"]["dynamos"]
    # colNames to be displayed
    colNames = {
        'model_name': 1,
        'model_id': 1, 
        'Category': 1, 
        'coordinate':1,
        'Location_Line': 1, 
        'Phase_Created':1,
        'Function': 1, 
        'Family': 1,
        'Level': 1,
        'coordinate': 1,
        'Assembly_Code': 1,
        'ML_filled': 1,
        '_id': 0,
        'Unit_Of_Measure': 1,
        'Location': 1,
        'Volume': 1,
        'Area': 1,
    }
    print('projectId: ',projectId)
    pipe = [
        { "$match":{"projectId": projectId, "modelId":modelId}},         
        {'$project': colNames},
        {'$sort': {'Assembly_Code': 1}}
    ]
    result = db.aggregate(pipe, allowDiskUse = True)
    db_docs = list(result)
    client.close()
    print('> Documents retrieved: ',len(db_docs))
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
        # dataRange = np.arrange(round(-1+min(df01['z-height']),0),2.0+max(df01['z-height']),2)
        dataRange = np.arange(2*min(levelsBelow0), 2*max(levelsAbove0)+1, 2)
    else:
        levels = np.arange(1,1+max(df01['z-height'])/2)
        dataRange = np.arange(0,2*max(levels)+1,2)
        #dataRange = np.arange(-1,1.0+max(df01['z-height']),2)

    print('No of levels',len(levels))
    print('Range of data',len(dataRange))

    dfCut = pd.cut(df01['z-height'], dataRange, labels=levels)
    df01['level_group'] = dfCut

    # use ML model to predict the assembly codes
    df01 = fillMissingValues(df01) if updateDB else df01 

    df01 = df01.sort_values(['z-height','level_group']) 
    df02 = df01.sort_values(['level_group','Assembly_Code'])

    print(df02.columns)

    # sorting by location, Measure Unit
    df02.loc[df02["Unit_Of_Measure"] == "m", "measureUnitTemp"] = 0
    df02.loc[df02["Unit_Of_Measure"] == "ft", "measureUnitTemp"] = 1
    df02.loc[df02["Unit_Of_Measure"] == "1 unit", "measureUnitTemp"] = 2
    sort_columns = ["level_group","Assembly_Code", "Location", "measureUnitTemp"]
    df02 = df02.sort_values(by=sort_columns, ascending=[True, True, True, True])

    df02['Volume'] = pd.to_numeric(df02['Volume'])
    volume_calc = df02[["Assembly_Code", "level_group", "Location", "Unit_Of_Measure", "Volume"]].groupby(["Assembly_Code", "level_group", "Location", "Unit_Of_Measure"], sort=False, as_index=False)
    volume_calc = volume_calc.agg(sum) #.reset_index()
    volume_calc.loc[volume_calc["Unit_Of_Measure"] == "m", "threshold"] = 200
    volume_calc.loc[volume_calc["Unit_Of_Measure"] == "ft", "threshold"] = 200
    volume_calc.loc[volume_calc["Unit_Of_Measure"] == "1 unit", "threshold"] = 100

    volume_calc["Volume"] = volume_calc["Volume"].fillna(0.0)
    volume_calc[volume_calc["Volume"].isin(["", '', ' ', " "])]["Volume"] = 0.0

    vols = []
    for i in volume_calc["Volume"].values:
        try:
            a = float(i)
            vols.append(a)
        except:
            vols.append(0.0)
    volume_calc["Volume"] = vols
    volume_calc["Volume"] = volume_calc["Volume"].astype(float)

    count = volume_calc[["Assembly_Code", "level_group", "Location", "Unit_Of_Measure", "Volume"]].groupby(["Assembly_Code", "level_group", "Location", "Unit_Of_Measure"]).count().reset_index()
    count = count.rename(columns={"Volume":"count"})

    volume_calc = volume_calc.sort_values(by="Assembly_Code")
    count = count.sort_values(by="Assembly_Code")

    volume_calc = pd.concat([volume_calc, count["count"]], axis=1)

    volume_calc["timeToComplete"] = round((volume_calc["count"] * volume_calc["Volume"]) / volume_calc["threshold"], 0)

    volume_calc.loc[volume_calc["Unit_Of_Measure"] == "m", "measureUnitTemp"] = 0
    volume_calc.loc[volume_calc["Unit_Of_Measure"] == "ft", "measureUnitTemp"] = 1
    volume_calc.loc[volume_calc["Unit_Of_Measure"] == "1 unit", "measureUnitTemp"] = 2
    sort_columns = ["level_group","Assembly_Code", "Location", "measureUnitTemp"]
    volume_calc = volume_calc.sort_values(by=sort_columns, ascending=[True, True, True, True])

    start_dates = []
    end_dates = []
    for i in volume_calc[["Assembly_Code", "level_group","Location", "Unit_Of_Measure", "timeToComplete"]].values:
        if start_dates == []:
            start = datetime.datetime.now()
            start = start.replace(hour=8, minute=0, second=0, microsecond=0)
            end = start + pd.to_timedelta(i[-1], unit = "d")
            end = end.replace(hour=17, minute=0, second=0, microsecond=0)
        else:
            start = end_dates[-1]
            start = start.replace(hour=8, minute=0, second=0, microsecond=0)
            end = start + pd.to_timedelta(i[-1], unit = "d")
            end = end.replace(hour=17, minute=0, second=0, microsecond=0)
        start_dates.append(start)
        end_dates.append(end)
    
    volume_calc["start_date"] = start_dates
    volume_calc["end_date"] = end_dates

    df02["start_date"] = None
    df02["end_date"] = None
    for i in volume_calc[["Assembly_Code", "level_group", "Location", "Unit_Of_Measure", "start_date", "end_date"]].values:
        df02.loc[(df02["Assembly_Code"] == i[0])&(df02["level_group"] == i[1])&(df02["Location"] == i[2])&(df02["Unit_Of_Measure"] == i[3]), "start_date"] = i[4]
        df02.loc[(df02["Assembly_Code"] == i[0])&(df02["level_group"] == i[1])&(df02["Location"] == i[2])&(df02["Unit_Of_Measure"] == i[3]), "end_date"] = i[5]   
    df02 = df02.drop(columns=["measureUnitTemp"])
    
    #df02.to_csv("volumne.csv", index=False)
    del volume_calc
    del count
    
    return (df01,df02,levels)

@app.route('/getdf02/<projectId>', methods=['GET'])
def getDatadf02(projectId):
    print('retrieving data in JSON')
    _, df02, _ = getDatafromMongo(projectId)
    return jsonify(df02.to_json(orient='records'))

@app.route('/getdf02csv/<projectId>', methods=['GET'])
def getDatadf02csv(projectId):
    print('retrieving data in CSV' +projectId)
    _, df02, _ = getDatafromMongo(projectId)
    df02Stream = BytesIO(df02.to_csv().encode())
    return send_file(
        df02Stream,
        mimetype="text/csv",
        attachment_filename="data02.csv",
        as_attachment=True
    )

@app.route('/updatedb/<projectId>/<modelId>', methods=['GET'])
def updatedb(projectId,modelId):
    # get missing model id lists
    print('> Call For DB Update',projectId,modelId)
    modelIds_List_missing = getAssemblyCodesList(projectId,modelId)
    if len(modelIds_List_missing) < 1:
        return jsonify({
            'updateMongo' : 'Failure',
            'message' : 'update db failed. No Missing Assembly Code found in DB.'
        })
    print('> Retrieved list of missing assembly codes : ',len(modelIds_List_missing))
    # get the data 
    # run machine learning model
    _, df02, _ = getDatafromMongo(projectId,modelId,updateDB=True) 
    boolean_series = df02.model_id.isin(modelIds_List_missing)
    filtered_df = df02[boolean_series]
    filtered_df['Assembly_Code'] = filtered_df['Assembly_Code'].replace('---','')
    filtered_df['ML_filled'] = filtered_df['ML_filled'].replace(0,1)
    print('> No of updated assembly codes updated using ML model : ',len(filtered_df))
    # df02Stream = BytesIO(filtered_df.to_csv().encode())
    # return send_file(
    #     df02Stream,
    #     mimetype="text/csv",
    #     attachment_filename="filtered_data.csv",
    #     as_attachment=True
    # )
    
    # update the data, update column based on the missing model ids
    # return success if update is success else return false
    if bulkUpdateDB(filtered_df) :
        return jsonify({
            'updateMongo' : 'Success',
            'message' : 'update db success with '+str(len(filtered_df))+' records.'
        })
    else:
        return jsonify({
            'updateMongo' : 'Failure',
            'message' : 'update db failed. Please check the service logs'
        })

@app.route('/downloaddata/<projectId>',  methods=['GET'])
def downloadData(projectId):
    print('retrieving data in ZIP')
    df01, df02, _ = getDatafromMongo(projectId)
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

@app.route('/getschedulecsv/<projectId>',methods=['GET'])
def getSchedule(projectId):
    _,df02,levels = getDatafromMongo(projectId)
    sch = df02[['Location_Line','model_name','Phase_Created','model_id','level_group', 'Assembly_Code']]
    sch.columns = ['Outline_level','Task_Name','Task_Type','Revit_id','level_group', 'Assembly_Code']
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
    sch = sch[['Active', 'Task_Mode', 'Task_Name', 'Duration (Days)', 'Planned_Start_Date', 'Planned_End_Date', 'Outline_level', 'Task_Type', 'level_group', 'Revit_id', 'Assembly_Code']]

    dataStream = BytesIO(sch.to_csv(date_format='%Y-%m-%d %H:%M:%S').encode())
    return send_file(
        dataStream,
        mimetype="text/csv",
        attachment_filename="schedule.csv",
        as_attachment=True
    )


@app.route('/getmissingdatacsv/<projectId>',methods=['GET'])
def getMissingData(projectId):
    print("> Retrieving missing data from the database - Started" +projectId)
    data = getMissingDataMongo(projectId)
    dataStream = BytesIO(data.to_csv(index=False, encoding='utf-8').encode())
    print("> Retrieved missing data from the database - Completed")
    return send_file(
        dataStream,
        mimetype="text/csv",
        attachment_filename="missing_data.csv",
        as_attachment=True
    )
    df02.to_csv("schedule.csv")

@app.route('/')
def sample():
    return "Prediction3D - Intelligent Construction - Flask API" 

if __name__ == '__main__':
    app.run(debug=True)
