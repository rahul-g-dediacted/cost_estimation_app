using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Gordian.DataApi.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace NetCoreClient.Models
{
    public class AssemblyCostLineEntity
    {
        [Key]
        public Guid Idd { get; set; }

        public string RsId { get; set; }

        public string LineNumber { get; set; }

        public string ReleaseId { get; set; }
        [ForeignKey(nameof(ReleaseId))]
        public ReleaseEntity ReleaseEntity { get; set; }

        public string AssemblyCatelogId { get; set; }
        [ForeignKey(nameof(AssemblyCatelogId))]
        public AssemblyCatelogEntity AssemblyCatelogEntity { get; set; }

        public double? Frequency { get; set; }
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string UnitOfMeasure { get; set; }

        [Column(TypeName = "jsonb")]
        public AssemblyLineCostData BaseCosts { get; set; }

        public string LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public LocationEntity LocationEntity { get; set; }

        [Column(TypeName = "jsonb")]
        public CostFactorData CostFactors { get; set; }

        [Column(TypeName = "jsonb")]
        public LocalAssemblyLineCostData LocalizedCosts { get; set; }

        [Column(TypeName = "jsonb")]
        public ReferenceListAssemblyUnitLineComponent AssemblyUnitCostLines { get; set; }

        public string Href { get;  set; }

    }
}
