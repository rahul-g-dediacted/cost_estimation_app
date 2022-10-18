using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreClient.Models
{
   public class LocationEntity
   {
      [Key]
      public string Id { get; set; }

      public string City { get; set; }

      public string StateCode { get; set; }

      public string CountryCode { get; set; }

      public string Href { get; set; }
   }
}
