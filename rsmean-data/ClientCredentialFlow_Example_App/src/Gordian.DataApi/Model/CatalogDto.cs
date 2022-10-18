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
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gordian.DataApi.Model
{
    /// <summary>
    /// CatalogDto
    /// </summary>
    [DataContract]
    public partial class CatalogDto :  IEquatable<CatalogDto>, IValidatableObject
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
        /// Initializes a new instance of the <see cref="CatalogDto" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="documentDate">documentDate.</param>
        /// <param name="isAddendum">isAddendum.</param>
        /// <param name="costDataFormat">costDataFormat.</param>
        /// <param name="measurementSystem">measurementSystem.</param>
        /// <param name="laborType">laborType.</param>
        public CatalogDto(string id = default(string), string name = default(string), DateTime? documentDate = default(DateTime?), bool? isAddendum = default(bool?), CostDataFormatEnum? costDataFormat = default(CostDataFormatEnum?), MeasurementSystemEnum? measurementSystem = default(MeasurementSystemEnum?), LaborTypeEnum? laborType = default(LaborTypeEnum?))
        {
            this.Id = id;
            this.Name = name;
            this.DocumentDate = documentDate;
            this.IsAddendum = isAddendum;
            this.CostDataFormat = costDataFormat;
            this.MeasurementSystem = measurementSystem;
            this.LaborType = laborType;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets DocumentDate
        /// </summary>
        [DataMember(Name="documentDate", EmitDefaultValue=false)]
        public DateTime? DocumentDate { get; set; }

        /// <summary>
        /// Gets or Sets IsAddendum
        /// </summary>
        [DataMember(Name="isAddendum", EmitDefaultValue=false)]
        public bool? IsAddendum { get; set; }




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
            sb.Append("class CatalogDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  DocumentDate: ").Append(DocumentDate).Append("\n");
            sb.Append("  IsAddendum: ").Append(IsAddendum).Append("\n");
            sb.Append("  CostDataFormat: ").Append(CostDataFormat).Append("\n");
            sb.Append("  MeasurementSystem: ").Append(MeasurementSystem).Append("\n");
            sb.Append("  LaborType: ").Append(LaborType).Append("\n");
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
            return this.Equals(input as CatalogDto);
        }

        /// <summary>
        /// Returns true if CatalogDto instances are equal
        /// </summary>
        /// <param name="input">Instance of CatalogDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CatalogDto input)
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
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.DocumentDate == input.DocumentDate ||
                    (this.DocumentDate != null &&
                    this.DocumentDate.Equals(input.DocumentDate))
                ) && 
                (
                    this.IsAddendum == input.IsAddendum ||
                    (this.IsAddendum != null &&
                    this.IsAddendum.Equals(input.IsAddendum))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.DocumentDate != null)
                    hashCode = hashCode * 59 + this.DocumentDate.GetHashCode();
                if (this.IsAddendum != null)
                    hashCode = hashCode * 59 + this.IsAddendum.GetHashCode();
                if (this.CostDataFormat != null)
                    hashCode = hashCode * 59 + this.CostDataFormat.GetHashCode();
                if (this.MeasurementSystem != null)
                    hashCode = hashCode * 59 + this.MeasurementSystem.GetHashCode();
                if (this.LaborType != null)
                    hashCode = hashCode * 59 + this.LaborType.GetHashCode();
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