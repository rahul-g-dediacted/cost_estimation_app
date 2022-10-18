using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gordian.DataApi.Model;
using MongoDB.Driver;
using NetCoreClient.Models;

namespace NetCoreClient
{
    public class MongoRSMeanService
    {
        public static MongoClient Client;
        public IMongoDatabase DataBase;

        public MongoRSMeanService()
        {
            Client = new MongoClient("mongodb+srv://feahm:eagle999@cluster0.izbcb.mongodb.net/Revit?retryWrites=true&w=majority");
            IMongoDatabase mongodb = Client.GetDatabase("Revit");
            DataBase = mongodb;


        }

        public void GetRelease(NonpagedListRelease list)
        {
            var l = list.Items;
            var collection = DataBase.GetCollection<Release>("RS");
            //collection.InsertMany(l);

        }

        public void AddAssemblyCatalog(NonpagedListAssemblyCatalog list,bool isDelete)
        {
            var l = list.Items;
            var collection = DataBase.GetCollection<AssemblyCatalog>("RSAssemblyCatalogs");
            if (isDelete)
            {
                collection.DeleteMany(x => true);
            }
         
            collection.InsertMany(l);
        }

        public void AddAssemblyCostLine(NonpagedListAssemblyCatalog catalogs, PagedListAssemblyCostLine list)
        {
            var collectionAssemblyCostLine = DataBase.GetCollection<AssemblyCostLine>("RSAssemblyCostLine");
            collectionAssemblyCostLine.DeleteMany(x=>true);

        }
    }
}
