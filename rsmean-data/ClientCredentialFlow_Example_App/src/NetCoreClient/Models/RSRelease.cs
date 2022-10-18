using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetCoreClient.Models
{
    public class RSRelease
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Year { get; set; }

        public string Period { get; set; }

        public string Description { get; set; }
        public string Href { get; set; }

    }
}
