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
    /// AssemblyDivision
    /// </summary>
    [DataContract]
    public partial class AssemblyDivision :  IEquatable<AssemblyDivision>, IValidatableObject
    {
        /// <summary>
        /// The cost data format.
        /// </summary>
        /// <value>The cost data format.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CostDataFormatEnum
        {
            
            /// <summary>
            /// Enum Uni for value: uni
            /// </summary>
            [EnumMember(Value = "uni")]
            Uni = 1,
            
            /// <summary>
            /// Enum Resi for value: resi
            /// </summary>
            [EnumMember(Value = "resi")]
            Resi = 2
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
        /// Initializes a new instance of the <see cref="AssemblyDivision" /> class.
        /// </summary>
        /// <param name="id">The division identifier..</param>
        /// <param name="costDataFormat">The cost data format..</param>
        /// <param name="measurementSystem">The measurement system..</param>
        /// <param name="divisionCode">The division code..</param>
        /// <param name="releaseYear">The release year..</param>
        /// <param name="parentId">The parent division identifier..</param>
        /// <param name="level">The level..</param>
        /// <param name="description">The division description..</param>
        /// <param name="note">Division note..</param>
        /// <param name="catalog">catalog.</param>
        /// <param name="parentDivision">parentDivision.</param>
        /// <param name="childDivisions">childDivisions.</param>
        public AssemblyDivision(string id = default(string), CostDataFormatEnum? costDataFormat = default(CostDataFormatEnum?), MeasurementSystemEnum? measurementSystem = default(MeasurementSystemEnum?), string divisionCode = default(string), string releaseYear = default(string), string parentId = default(string), int? level = default(int?), string description = default(string), string note = default(string), ReferenceAssemblyCatalog catalog = default(ReferenceAssemblyCatalog), ReferenceAssemblyDivision parentDivision = default(ReferenceAssemblyDivision), ReferenceListAssemblyDivision childDivisions = default(ReferenceListAssemblyDivision))
        {
            this.Id = id;
            this.CostDataFormat = costDataFormat;
            this.MeasurementSystem = measurementSystem;
            this.DivisionCode = divisionCode;
            this.ReleaseYear = releaseYear;
            this.ParentId = parentId;
            this.Level = level;
            this.Description = description;
            this.Note = note;
            this.Catalog = catalog;
            this.ParentDivision = parentDivision;
            this.ChildDivisions = childDivisions;
        }
        
        /// <summary>
        /// The division identifier.
        /// </summary>
        /// <value>The division identifier.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }



        /// <summary>
        /// The division code.
        /// </summary>
        /// <value>The division code.</value>
        [DataMember(Name="divisionCode", EmitDefaultValue=false)]
        public string DivisionCode { get; set; }

        /// <summary>
        /// The release year.
        /// </summary>
        /// <value>The release year.</value>
        [DataMember(Name="releaseYear", EmitDefaultValue=false)]
        public string ReleaseYear { get; set; }

        /// <summary>
        /// The parent division identifier.
        /// </summary>
        /// <value>The parent division identifier.</value>
        [DataMember(Name="parentId", EmitDefaultValue=false)]
        public string ParentId { get; set; }

        /// <summary>
        /// The level.
        /// </summary>
        /// <value>The level.</value>
        [DataMember(Name="level", EmitDefaultValue=false)]
        public int? Level { get; set; }

        /// <summary>
        /// The division description.
        /// </summary>
        /// <value>The division description.</value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Division note.
        /// </summary>
        /// <value>Division note.</value>
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// Gets or Sets Catalog
        /// </summary>
        [DataMember(Name="catalog", EmitDefaultValue=false)]
        public ReferenceAssemblyCatalog Catalog { get; set; }

        /// <summary>
        /// Gets or Sets ParentDivision
        /// </summary>
        [DataMember(Name="parentDivision", EmitDefaultValue=false)]
        public ReferenceAssemblyDivision ParentDivision { get; set; }

        /// <summary>
        /// Gets or Sets ChildDivisions
        /// </summary>
        [DataMember(Name="childDivisions", EmitDefaultValue=false)]
        public ReferenceListAssemblyDivision ChildDivisions { get; set; }

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
            sb.Append("class AssemblyDivision {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CostDataFormat: ").Append(CostDataFormat).Append("\n");
            sb.Append("  MeasurementSystem: ").Append(MeasurementSystem).Append("\n");
            sb.Append("  DivisionCode: ").Append(DivisionCode).Append("\n");
            sb.Append("  ReleaseYear: ").Append(ReleaseYear).Append("\n");
            sb.Append("  ParentId: ").Append(ParentId).Append("\n");
            sb.Append("  Level: ").Append(Level).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  Catalog: ").Append(Catalog).Append("\n");
            sb.Append("  ParentDivision: ").Append(ParentDivision).Append("\n");
            sb.Append("  ChildDivisions: ").Append(ChildDivisions).Append("\n");
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
            return this.Equals(input as AssemblyDivision);
        }

        /// <summary>
        /// Returns true if AssemblyDivision instances are equal
        /// </summary>
        /// <param name="input">Instance of AssemblyDivision to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AssemblyDivision input)
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
                    this.DivisionCode == input.DivisionCode ||
                    (this.DivisionCode != null &&
                    this.DivisionCode.Equals(input.DivisionCode))
                ) && 
                (
                    this.ReleaseYear == input.ReleaseYear ||
                    (this.ReleaseYear != null &&
                    this.ReleaseYear.Equals(input.ReleaseYear))
                ) && 
                (
                    this.ParentId == input.ParentId ||
                    (this.ParentId != null &&
                    this.ParentId.Equals(input.ParentId))
                ) && 
                (
                    this.Level == input.Level ||
                    (this.Level != null &&
                    this.Level.Equals(input.Level))
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
                    this.Catalog == input.Catalog ||
                    (this.Catalog != null &&
                    this.Catalog.Equals(input.Catalog))
                ) && 
                (
                    this.ParentDivision == input.ParentDivision ||
                    (this.ParentDivision != null &&
                    this.ParentDivision.Equals(input.ParentDivision))
                ) && 
                (
                    this.ChildDivisions == input.ChildDivisions ||
                    (this.ChildDivisions != null &&
                    this.ChildDivisions.Equals(input.ChildDivisions))
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
                if (this.CostDataFormat != null)
                    hashCode = hashCode * 59 + this.CostDataFormat.GetHashCode();
                if (this.MeasurementSystem != null)
                    hashCode = hashCode * 59 + this.MeasurementSystem.GetHashCode();
                if (this.DivisionCode != null)
                    hashCode = hashCode * 59 + this.DivisionCode.GetHashCode();
                if (this.ReleaseYear != null)
                    hashCode = hashCode * 59 + this.ReleaseYear.GetHashCode();
                if (this.ParentId != null)
                    hashCode = hashCode * 59 + this.ParentId.GetHashCode();
                if (this.Level != null)
                    hashCode = hashCode * 59 + this.Level.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
                if (this.Catalog != null)
                    hashCode = hashCode * 59 + this.Catalog.GetHashCode();
                if (this.ParentDivision != null)
                    hashCode = hashCode * 59 + this.ParentDivision.GetHashCode();
                if (this.ChildDivisions != null)
                    hashCode = hashCode * 59 + this.ChildDivisions.GetHashCode();
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
