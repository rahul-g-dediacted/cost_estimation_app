/* 
 * RSMeans Consumer REST API V1
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gordian.DataApi.Model
{
    /// <summary>
    /// EquipmentRentalCostLine
    /// </summary>
    [DataContract]
    public partial class EquipmentRentalCostLine :  IEquatable<EquipmentRentalCostLine>, IValidatableObject
    {
        /// <summary>
        /// Defines CostDataFormat
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CostDataFormatEnum
        {
            
            /// <summary>
            /// Enum Mf for value: mf
            /// </summary>
            [EnumMember(Value = "mf")]
            Mf = 1,
            
            /// <summary>
            /// Enum Mf95 for value: mf95
            /// </summary>
            [EnumMember(Value = "mf95")]
            Mf95 = 2
        }

        /// <summary>
        /// Gets or Sets CostDataFormat
        /// </summary>
        [DataMember(Name="costDataFormat", EmitDefaultValue=false)]
        public CostDataFormatEnum? CostDataFormat { get; set; }
        /// <summary>
        /// Defines MeasurementSystem
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MeasurementSystemEnum
        {
            
            /// <summary>
            /// Enum Imp for value: imp
            /// </summary>
            [EnumMember(Value = "imp")]
            Imp = 1,
            
            /// <summary>
            /// Enum Met for value: met
            /// </summary>
            [EnumMember(Value = "met")]
            Met = 2
        }

        /// <summary>
        /// Gets or Sets MeasurementSystem
        /// </summary>
        [DataMember(Name="measurementSystem", EmitDefaultValue=false)]
        public MeasurementSystemEnum? MeasurementSystem { get; set; }
        /// <summary>
        /// Defines LaborType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum LaborTypeEnum
        {
            
            /// <summary>
            /// Enum Std for value: std
            /// </summary>
            [EnumMember(Value = "std")]
            Std = 1,
            
            /// <summary>
            /// Enum Opn for value: opn
            /// </summary>
            [EnumMember(Value = "opn")]
            Opn = 2,
            
            /// <summary>
            /// Enum Fmr for value: fmr
            /// </summary>
            [EnumMember(Value = "fmr")]
            Fmr = 3,
            
            /// <summary>
            /// Enum Res for value: res
            /// </summary>
            [EnumMember(Value = "res")]
            Res = 4,
            
            /// <summary>
            /// Enum Rr for value: rr
            /// </summary>
            [EnumMember(Value = "rr")]
            Rr = 5,
            
            /// <summary>
            /// Enum Fed for value: fed
            /// </summary>
            [EnumMember(Value = "fed")]
            Fed = 6
        }

        /// <summary>
        /// Gets or Sets LaborType
        /// </summary>
        [DataMember(Name="laborType", EmitDefaultValue=false)]
        public LaborTypeEnum? LaborType { get; set; }
        /// <summary>
        /// Defines CostLineType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CostLineTypeEnum
        {
            
            /// <summary>
            /// Enum Unknown for value: unknown
            /// </summary>
            [EnumMember(Value = "unknown")]
            Unknown = 1,
            
            /// <summary>
            /// Enum Install for value: install
            /// </summary>
            [EnumMember(Value = "install")]
            Install = 2,
            
            /// <summary>
            /// Enum Demo for value: demo
            /// </summary>
            [EnumMember(Value = "demo")]
            Demo = 3,
            
            /// <summary>
            /// Enum Trade for value: trade
            /// </summary>
            [EnumMember(Value = "trade")]
            Trade = 4,
            
            /// <summary>
            /// Enum Equipment for value: equipment
            /// </summary>
            [EnumMember(Value = "equipment")]
            Equipment = 5
        }

        /// <summary>
        /// Gets or Sets CostLineType
        /// </summary>
        [DataMember(Name="costLineType", EmitDefaultValue=false)]
        public CostLineTypeEnum? CostLineType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentRentalCostLine" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="lineNumber">lineNumber.</param>
        /// <param name="release">release.</param>
        /// <param name="catalog">catalog.</param>
        /// <param name="costDataFormat">costDataFormat.</param>
        /// <param name="measurementSystem">measurementSystem.</param>
        /// <param name="laborType">laborType.</param>
        /// <param name="hierarchies">hierarchies.</param>
        /// <param name="shortDescription">shortDescription.</param>
        /// <param name="description">description.</param>
        /// <param name="unitOfMeasure">unitOfMeasure.</param>
        /// <param name="location">location.</param>
        /// <param name="costFactors">costFactors.</param>
        /// <param name="baseCosts">baseCosts.</param>
        /// <param name="localizedCosts">localizedCosts.</param>
        public EquipmentRentalCostLine(string id = default(string), string lineNumber = default(string), ReferenceRelease release = default(ReferenceRelease), ReferenceUnitCatalog catalog = default(ReferenceUnitCatalog), CostDataFormatEnum? costDataFormat = default(CostDataFormatEnum?), MeasurementSystemEnum? measurementSystem = default(MeasurementSystemEnum?), LaborTypeEnum? laborType = default(LaborTypeEnum?), List<UnitDivisionLight> hierarchies = default(List<UnitDivisionLight>), string shortDescription = default(string), string description = default(string), string unitOfMeasure = default(string), ReferenceLocation location = default(ReferenceLocation), CostFactorData costFactors = default(CostFactorData), EquipmentRentalCosts baseCosts = default(EquipmentRentalCosts), EquipmentRentalCosts localizedCosts = default(EquipmentRentalCosts))
        {
            this.Id = id;
            this.LineNumber = lineNumber;
            this.Release = release;
            this.Catalog = catalog;
            this.CostDataFormat = costDataFormat;
            this.MeasurementSystem = measurementSystem;
            this.LaborType = laborType;
            this.Hierarchies = hierarchies;
            this.ShortDescription = shortDescription;
            this.Description = description;
            this.UnitOfMeasure = unitOfMeasure;
            this.Location = location;
            this.CostFactors = costFactors;
            this.BaseCosts = baseCosts;
            this.LocalizedCosts = localizedCosts;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets LineNumber
        /// </summary>
        [DataMember(Name="lineNumber", EmitDefaultValue=false)]
        public string LineNumber { get; set; }

        /// <summary>
        /// Gets or Sets Release
        /// </summary>
        [DataMember(Name="release", EmitDefaultValue=false)]
        public ReferenceRelease Release { get; set; }

        /// <summary>
        /// Gets or Sets Catalog
        /// </summary>
        [DataMember(Name="catalog", EmitDefaultValue=false)]
        public ReferenceUnitCatalog Catalog { get; set; }




        /// <summary>
        /// Gets or Sets Hierarchies
        /// </summary>
        [DataMember(Name="hierarchies", EmitDefaultValue=false)]
        public List<UnitDivisionLight> Hierarchies { get; set; }

        /// <summary>
        /// Gets or Sets ShortDescription
        /// </summary>
        [DataMember(Name="shortDescription", EmitDefaultValue=false)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets UnitOfMeasure
        /// </summary>
        [DataMember(Name="unitOfMeasure", EmitDefaultValue=false)]
        public string UnitOfMeasure { get; set; }


        /// <summary>
        /// Gets or Sets Location
        /// </summary>
        [DataMember(Name="location", EmitDefaultValue=false)]
        public ReferenceLocation Location { get; set; }

        /// <summary>
        /// Gets or Sets CostFactors
        /// </summary>
        [DataMember(Name="costFactors", EmitDefaultValue=false)]
        public CostFactorData CostFactors { get; set; }

        /// <summary>
        /// Gets or Sets BaseCosts
        /// </summary>
        [DataMember(Name="baseCosts", EmitDefaultValue=false)]
        public EquipmentRentalCosts BaseCosts { get; set; }

        /// <summary>
        /// Gets or Sets LocalizedCosts
        /// </summary>
        [DataMember(Name="localizedCosts", EmitDefaultValue=false)]
        public EquipmentRentalCosts LocalizedCosts { get; set; }

        /// <summary>
        /// Gets or Sets Href
        /// </summary>
        [DataMember(Name="href", EmitDefaultValue=false)]
        public string Href { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EquipmentRentalCostLine {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LineNumber: ").Append(LineNumber).Append("\n");
            sb.Append("  Release: ").Append(Release).Append("\n");
            sb.Append("  Catalog: ").Append(Catalog).Append("\n");
            sb.Append("  CostDataFormat: ").Append(CostDataFormat).Append("\n");
            sb.Append("  MeasurementSystem: ").Append(MeasurementSystem).Append("\n");
            sb.Append("  LaborType: ").Append(LaborType).Append("\n");
            sb.Append("  Hierarchies: ").Append(Hierarchies).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  UnitOfMeasure: ").Append(UnitOfMeasure).Append("\n");
            sb.Append("  CostLineType: ").Append(CostLineType).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  CostFactors: ").Append(CostFactors).Append("\n");
            sb.Append("  BaseCosts: ").Append(BaseCosts).Append("\n");
            sb.Append("  LocalizedCosts: ").Append(LocalizedCosts).Append("\n");
            sb.Append("  Href: ").Append(Href).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as EquipmentRentalCostLine);
        }

        /// <summary>
        /// Returns true if EquipmentRentalCostLine instances are equal
        /// </summary>
        /// <param name="input">Instance of EquipmentRentalCostLine to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EquipmentRentalCostLine input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.LineNumber == input.LineNumber ||
                    (this.LineNumber != null &&
                    this.LineNumber.Equals(input.LineNumber))
                ) && 
                (
                    this.Release == input.Release ||
                    (this.Release != null &&
                    this.Release.Equals(input.Release))
                ) && 
                (
                    this.Catalog == input.Catalog ||
                    (this.Catalog != null &&
                    this.Catalog.Equals(input.Catalog))
                ) && 
                (
                    this.CostDataFormat == input.CostDataFormat ||
                    (this.CostDataFormat != null &&
                    this.CostDataFormat.Equals(input.CostDataFormat))
                ) && 
                (
                    this.MeasurementSystem == input.MeasurementSystem ||
                    (this.MeasurementSystem != null &&
                    this.MeasurementSystem.Equals(input.MeasurementSystem))
                ) && 
                (
                    this.LaborType == input.LaborType ||
                    (this.LaborType != null &&
                    this.LaborType.Equals(input.LaborType))
                ) && 
                (
                    this.Hierarchies == input.Hierarchies ||
                    this.Hierarchies != null &&
                    this.Hierarchies.SequenceEqual(input.Hierarchies)
                ) && 
                (
                    this.ShortDescription == input.ShortDescription ||
                    (this.ShortDescription != null &&
                    this.ShortDescription.Equals(input.ShortDescription))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.UnitOfMeasure == input.UnitOfMeasure ||
                    (this.UnitOfMeasure != null &&
                    this.UnitOfMeasure.Equals(input.UnitOfMeasure))
                ) && 
                (
                    this.CostLineType == input.CostLineType ||
                    (this.CostLineType != null &&
                    this.CostLineType.Equals(input.CostLineType))
                ) && 
                (
                    this.Location == input.Location ||
                    (this.Location != null &&
                    this.Location.Equals(input.Location))
                ) && 
                (
                    this.CostFactors == input.CostFactors ||
                    (this.CostFactors != null &&
                    this.CostFactors.Equals(input.CostFactors))
                ) && 
                (
                    this.BaseCosts == input.BaseCosts ||
                    (this.BaseCosts != null &&
                    this.BaseCosts.Equals(input.BaseCosts))
                ) && 
                (
                    this.LocalizedCosts == input.LocalizedCosts ||
                    (this.LocalizedCosts != null &&
                    this.LocalizedCosts.Equals(input.LocalizedCosts))
                ) && 
                (
                    this.Href == input.Href ||
                    (this.Href != null &&
                    this.Href.Equals(input.Href))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.LineNumber != null)
                    hashCode = hashCode * 59 + this.LineNumber.GetHashCode();
                if (this.Release != null)
                    hashCode = hashCode * 59 + this.Release.GetHashCode();
                if (this.Catalog != null)
                    hashCode = hashCode * 59 + this.Catalog.GetHashCode();
                if (this.CostDataFormat != null)
                    hashCode = hashCode * 59 + this.CostDataFormat.GetHashCode();
                if (this.MeasurementSystem != null)
                    hashCode = hashCode * 59 + this.MeasurementSystem.GetHashCode();
                if (this.LaborType != null)
                    hashCode = hashCode * 59 + this.LaborType.GetHashCode();
                if (this.Hierarchies != null)
                    hashCode = hashCode * 59 + this.Hierarchies.GetHashCode();
                if (this.ShortDescription != null)
                    hashCode = hashCode * 59 + this.ShortDescription.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.UnitOfMeasure != null)
                    hashCode = hashCode * 59 + this.UnitOfMeasure.GetHashCode();
                if (this.CostLineType != null)
                    hashCode = hashCode * 59 + this.CostLineType.GetHashCode();
                if (this.Location != null)
                    hashCode = hashCode * 59 + this.Location.GetHashCode();
                if (this.CostFactors != null)
                    hashCode = hashCode * 59 + this.CostFactors.GetHashCode();
                if (this.BaseCosts != null)
                    hashCode = hashCode * 59 + this.BaseCosts.GetHashCode();
                if (this.LocalizedCosts != null)
                    hashCode = hashCode * 59 + this.LocalizedCosts.GetHashCode();
                if (this.Href != null)
                    hashCode = hashCode * 59 + this.Href.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
