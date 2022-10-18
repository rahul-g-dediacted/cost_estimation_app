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

namespace Gordian.DataApi.Model
{
    /// <summary>
    /// Area and related perimeter
    /// </summary>
    [DataContract]
    public partial class BuildingAreaPerimeter :  IEquatable<BuildingAreaPerimeter>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingAreaPerimeter" /> class.
        /// </summary>
        /// <param name="area">The area..</param>
        /// <param name="perimeter">The Perimeter..</param>
        public BuildingAreaPerimeter(double? area = default(double?), double? perimeter = default(double?))
        {
            this.Area = area;
            this.Perimeter = perimeter;
        }
        
        /// <summary>
        /// The area.
        /// </summary>
        /// <value>The area.</value>
        [DataMember(Name="area", EmitDefaultValue=false)]
        public double? Area { get; set; }

        /// <summary>
        /// The Perimeter.
        /// </summary>
        /// <value>The Perimeter.</value>
        [DataMember(Name="perimeter", EmitDefaultValue=false)]
        public double? Perimeter { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BuildingAreaPerimeter {\n");
            sb.Append("  Area: ").Append(Area).Append("\n");
            sb.Append("  Perimeter: ").Append(Perimeter).Append("\n");
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
            return this.Equals(input as BuildingAreaPerimeter);
        }

        /// <summary>
        /// Returns true if BuildingAreaPerimeter instances are equal
        /// </summary>
        /// <param name="input">Instance of BuildingAreaPerimeter to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BuildingAreaPerimeter input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Area == input.Area ||
                    (this.Area != null &&
                    this.Area.Equals(input.Area))
                ) && 
                (
                    this.Perimeter == input.Perimeter ||
                    (this.Perimeter != null &&
                    this.Perimeter.Equals(input.Perimeter))
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
                if (this.Area != null)
                    hashCode = hashCode * 59 + this.Area.GetHashCode();
                if (this.Perimeter != null)
                    hashCode = hashCode * 59 + this.Perimeter.GetHashCode();
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
