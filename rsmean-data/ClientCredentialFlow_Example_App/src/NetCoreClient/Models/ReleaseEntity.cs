using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetCoreClient.Models
{
   public class ReleaseEntity
   {
      [Key]
      public string Id { get; set; }

      public string Year { get; set; }
      public string Year2 { get; set; }

      public string Period { get; set; }

      public string Description { get; set; }
      public string Href { get; set; }

   }
}
