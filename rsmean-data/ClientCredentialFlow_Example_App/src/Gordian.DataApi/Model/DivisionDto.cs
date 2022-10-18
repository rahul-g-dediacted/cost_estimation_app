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
    /// DivisionDto
    /// </summary>
    [DataContract]
    public partial class DivisionDto :  IEquatable<DivisionDto>, IValidatableObject
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
        /// Initializes a new instance of the <see cref="DivisionDto" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="divisionCode">divisionCode.</param>
        /// <param name="costDataFormat">costDataFormat.</param>
        /// <param name="measurementSystem">measurementSystem.</param>
        /// <param name="description">description.</param>
        /// <param name="note">note.</param>
        /// <param name="level">level.</param>
        /// <param name="catalogReference">catalogReference.</param>
        /// <param name="parentId">parentId.</param>
        /// <param name="parentDivisionReference">parentDivisionReference.</param>
        /// <param name="childDivisionsReference">childDivisionsReference.</param>
        /// <param name="childDivisions">childDivisions.</param>
        /// <param name="specsReference">specsReference.</param>
        public DivisionDto(string id = default(string), string divisionCode = default(string), CostDataFormatEnum? costDataFormat = default(CostDataFormatEnum?), MeasurementSystemEnum? measurementSystem = default(MeasurementSystemEnum?), string description = default(string), string note = default(string), int? level = default(int?), ReferenceCatalogDto catalogReference = default(ReferenceCatalogDto), string parentId = default(string), ReferenceDivisionDto parentDivisionReference = default(ReferenceDivisionDto), ReferenceListDivisionDto childDivisionsReference = default(ReferenceListDivisionDto), NonpagedListDivisionDto childDivisions = default(NonpagedListDivisionDto), ReferenceListSpecDto specsReference = default(ReferenceListSpecDto))
        {
            this.Id = id;
            this.DivisionCode = divisionCode;
            this.CostDataFormat = costDataFormat;
            this.MeasurementSystem = measurementSystem;
            this.Description = description;
            this.Note = note;
            this.Level = level;
            this.CatalogReference = catalogReference;
            this.ParentId = parentId;
            this.ParentDivisionReference = parentDivisionReference;
            this.ChildDivisionsReference = childDivisionsReference;
            this.ChildDivisions = childDivisions;
            this.SpecsReference = specsReference;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets DivisionCode
        /// </summary>
        [DataMember(Name="divisionCode", EmitDefaultValue=false)]
        public string DivisionCode { get; set; }



        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Note
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or Sets Level
        /// </summary>
        [DataMember(Name="level", EmitDefaultValue=false)]
        public int? Level { get; set; }

        /// <summary>
        /// Gets or Sets CatalogReference
        /// </summary>
        [DataMember(Name="catalogReference", EmitDefaultValue=false)]
        public ReferenceCatalogDto CatalogReference { get; set; }

        /// <summary>
        /// Gets or Sets ParentId
        /// </summary>
        [DataMember(Name="parentId", EmitDefaultValue=false)]
        public string ParentId { get; set; }

        /// <summary>
        /// Gets or Sets ParentDivisionReference
        /// </summary>
        [DataMember(Name="parentDivisionReference", EmitDefaultValue=false)]
        public ReferenceDivisionDto ParentDivisionReference { get; set; }

        /// <summary>
        /// Gets or Sets ChildDivisionsReference
        /// </summary>
        [DataMember(Name="childDivisionsReference", EmitDefaultValue=false)]
        public ReferenceListDivisionDto ChildDivisionsReference { get; set; }

        /// <summary>
        /// Gets or Sets ChildDivisions
        /// </summary>
        [DataMember(Name="childDivisions", EmitDefaultValue=false)]
        public NonpagedListDivisionDto ChildDivisions { get; set; }

        /// <summary>
        /// Gets or Sets SpecsReference
        /// </summary>
        [DataMember(Name="specsReference", EmitDefaultValue=false)]
        public ReferenceListSpecDto SpecsReference { get; set; }

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
            sb.Append("class DivisionDto {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DivisionCode: ").Append(DivisionCode).Append("\n");
            sb.Append("  CostDataFormat: ").Append(CostDataFormat).Append("\n");
            sb.Append("  MeasurementSystem: ").Append(MeasurementSystem).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  Level: ").Append(Level).Append("\n");
            sb.Append("  CatalogReference: ").Append(CatalogReference).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
            sb.Append("  ParentDivisionReference: ").Append(ParentDivisionReference).Append("\n");
            sb.Append("  ChildDivisionsReference: ").Append(ChildDivisionsReference).Append("\n");
            sb.Append("  ChildDivisions: ").Append(ChildDivisions).Append("\n");
            sb.Append("  SpecsReference: ").Append(SpecsReference).Append("\n");
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
            return this.Equals(input as DivisionDto);
        }

        /// <summary>
        /// Returns true if DivisionDto instances are equal
        /// </summary>
        /// <param name="input">Instance of DivisionDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DivisionDto input)
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
                    this.DivisionCode == input.DivisionCode ||
                    (this.DivisionCode != null &&
                    this.DivisionCode.Equals(input.DivisionCode))
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
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
                ) && 
                (
                    this.Level == input.Level ||
                    (this.Level != null &&
                    this.Level.Equals(input.Level))
                ) && 
                (
                    this.CatalogReference == input.CatalogReference ||
                    (this.CatalogReference != null &&
                    this.CatalogReference.Equals(input.CatalogReference))
                ) && 
                (
                    this.ParentId == input.ParentId ||
                    (this.ParentId != null &&
                    this.ParentId.Equals(input.ParentId))
                ) && 
                (
                    this.ParentDivisionReference == input.ParentDivisionReference ||
                    (this.ParentDivisionReference != null &&
                    this.ParentDivisionReference.Equals(input.ParentDivisionReference))
                ) && 
                (
                    this.ChildDivisionsReference == input.ChildDivisionsReference ||
                    (this.ChildDivisionsReference != null &&
                    this.ChildDivisionsReference.Equals(input.ChildDivisionsReference))
                ) && 
                (
                    this.ChildDivisions == input.ChildDivisions ||
                    (this.ChildDivisions != null &&
                    this.ChildDivisions.Equals(input.ChildDivisions))
                ) && 
                (
                    this.SpecsReference == input.SpecsReference ||
                    (this.SpecsReference != null &&
                    this.SpecsReference.Equals(input.SpecsReference))
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
                if (this.DivisionCode != null)
                    hashCode = hashCode * 59 + this.DivisionCode.GetHashCode();
                if (this.CostDataFormat != null)
                    hashCode = hashCode * 59 + this.CostDataFormat.GetHashCode();
                if (this.MeasurementSystem != null)
                    hashCode = hashCode * 59 + this.MeasurementSystem.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
                if (this.Level != null)
                    hashCode = hashCode * 59 + this.Level.GetHashCode();
                if (this.CatalogReference != null)
                    hashCode = hashCode * 59 + this.CatalogReference.GetHashCode();
                if (this.ParentId != null)
                    hashCode = hashCode * 59 + this.ParentId.GetHashCode();
                if (this.ParentDivisionReference != null)
                    hashCode = hashCode * 59 + this.ParentDivisionReference.GetHashCode();
                if (this.ChildDivisionsReference != null)
                    hashCode = hashCode * 59 + this.ChildDivisionsReference.GetHashCode();
                if (this.ChildDivisions != null)
                    hashCode = hashCode * 59 + this.ChildDivisions.GetHashCode();
                if (this.SpecsReference != null)
                    hashCode = hashCode * 59 + this.SpecsReference.GetHashCode();
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