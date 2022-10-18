using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreClient.Models
{
    public class AssemblyCatelogEntity
    {
        [Key]
        public string Id { get; set; }

        public string CatalogName { get; set; }
        [ForeignKey(nameof(ReleaseEntity))]
        public string ReleaseId { get; set; }

        public ReleaseEntity ReleaseEntity { get; set; }
        [ForeignKey(nameof(LocationEntity))]
        public string LocationId { get; set; }
        public LocationEntity LocationEntity { get; set; }
        public string Href { get;  set; }

    }
}
