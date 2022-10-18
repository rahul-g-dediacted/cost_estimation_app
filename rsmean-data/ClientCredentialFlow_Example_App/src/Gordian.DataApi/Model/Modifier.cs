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
    /// Modifier.
    /// </summary>
    [DataContract]
    public partial class Modifier :  IEquatable<Modifier>, IValidatableObject
    {
        /// <summary>
        /// The cost data format.
        /// </summary>
        /// <value>The cost data format.</value>
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
        /// The cost data format.
        /// </summary>
        /// <value>The cost data format.</value>
        [DataMember(Name="costDataFormat", EmitDefaultValue=false)]
        public CostDataFormatEnum? CostDataFormat { get; set; }
        /// <summary>
        /// The measurement system.
        /// </summary>
        /// <value>The measurement system.</value>
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
        /// The measurement system.
        /// </summary>
        /// <value>The measurement system.</value>
        [DataMember(Name="measurementSystem", EmitDefaultValue=false)]
        public MeasurementSystemEnum? MeasurementSystem { get; set; }
        /// <summary>
        /// Gets or sets the type of the labor.
        /// </summary>
        /// <value>Gets or sets the type of the labor.</value>
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
        /// Gets or sets the type of the labor.
        /// </summary>
        /// <value>Gets or sets the type of the labor.</value>
        [DataMember(Name="laborType", EmitDefaultValue=false)]
        public LaborTypeEnum? LaborType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Modifier" /> class.
        /// </summary>
        /// <param name="id">The Modifier identifier..</param>
        /// <param name="costDataFormat">The cost data format..</param>
        /// <param name="measurementSystem">The measurement system..</param>
        /// <param name="laborType">Gets or sets the type of the labor..</param>
        /// <param name="lineNumber">The line number..</param>
        /// <param name="releaseYear">The release year..</param>
        /// <param name="shortDescription">The short description..</param>
        /// <param name="description">The description..</param>
        /// <param name="percentValues">The percent values..</param>
        public Modifier(string id = default(string), CostDataFormatEnum? costDataFormat = default(CostDataFormatEnum?), MeasurementSystemEnum? measurementSystem = default(MeasurementSystemEnum?), LaborTypeEnum? laborType = default(LaborTypeEnum?), string lineNumber = default(string), string releaseYear = default(string), string shortDescription = default(string), string description = default(string), UnitLineCostData percentValues = default(UnitLineCostData))
        {
            this.Id = id;
            this.CostDataFormat = costDataFormat;
            this.MeasurementSystem = measurementSystem;
            this.LaborType = laborType;
            this.LineNumber = lineNumber;
            this.ReleaseYear = releaseYear;
            this.ShortDescription = shortDescription;
            this.Description = description;
            this.PercentValues = percentValues;
        }
        
        /// <summary>
        /// The Modifier identifier.
        /// </summary>
        /// <value>The Modifier identifier.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }




        /// <summary>
        /// The line number.
        /// </summary>
        /// <value>The line number.</value>
        [DataMember(Name="lineNumber", EmitDefaultValue=false)]
        public string LineNumber { get; set; }

        /// <summary>
        /// The release year.
        /// </summary>
        /// <value>The release year.</value>
        [DataMember(Name="releaseYear", EmitDefaultValue=false)]
        public string ReleaseYear { get; set; }

        /// <summary>
        /// The short description.
        /// </summary>
        /// <value>The short description.</value>
        [DataMember(Name="shortDescription", EmitDefaultValue=false)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// The description.
        /// </summary>
        /// <value>The description.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// The percent values.
        /// </summary>
        /// <value>The percent values.</value>
        [DataMember(Name="percentValues", EmitDefaultValue=false)]
        public UnitLineCostData PercentValues { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Modifier {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CostDataFormat: ").Append(CostDataFormat).Append("\n");
            sb.Append("  MeasurementSystem: ").Append(MeasurementSystem).Append("\n");
            sb.Append("  LaborType: ").Append(LaborType).Append("\n");
            sb.Append("  LineNumber: ").Append(LineNumber).Append("\n");
            sb.Append("  ReleaseYear: ").Append(ReleaseYear).Append("\n");
            sb.Append("  ShortDescription: ").Append(ShortDescription).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  PercentValues: ").Append(PercentValues).Append("\n");
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
            return this.Equals(input as Modifier);
        }

        /// <summary>
        /// Returns true if Modifier instances are equal
        /// </summary>
        /// <param name="input">Instance of Modifier to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Modifier input)
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
                    this.LineNumber == input.LineNumber ||
                    (this.LineNumber != null &&
                    this.LineNumber.Equals(input.LineNumber))
                ) && 
                (
                    this.ReleaseYear == input.ReleaseYear ||
                    (this.ReleaseYear != null &&
                    this.ReleaseYear.Equals(input.ReleaseYear))
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
                    this.PercentValues == input.PercentValues ||
                    (this.PercentValues != null &&
                    this.PercentValues.Equals(input.PercentValues))
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
                if (this.CostDataFormat != null)
                    hashCode = hashCode * 59 + this.CostDataFormat.GetHashCode();
                if (this.MeasurementSystem != null)
                    hashCode = hashCode * 59 + this.MeasurementSystem.GetHashCode();
                if (this.LaborType != null)
                    hashCode = hashCode * 59 + this.LaborType.GetHashCode();
                if (this.LineNumber != null)
                    hashCode = hashCode * 59 + this.LineNumber.GetHashCode();
                if (this.ReleaseYear != null)
                    hashCode = hashCode * 59 + this.ReleaseYear.GetHashCode();
                if (this.ShortDescription != null)
                    hashCode = hashCode * 59 + this.ShortDescription.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.PercentValues != null)
                    hashCode = hashCode * 59 + this.PercentValues.GetHashCode();
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
