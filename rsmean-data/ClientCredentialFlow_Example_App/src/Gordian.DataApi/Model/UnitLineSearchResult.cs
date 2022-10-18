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
    /// UnitLineSearchResult
    /// </summary>
    [DataContract]
    public partial class UnitLineSearchResult :  IEquatable<UnitLineSearchResult>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitLineSearchResult" /> class.
        /// </summary>
        /// <param name="aggregations">aggregations.</param>
        /// <param name="unitLines">unitLines.</param>
        public UnitLineSearchResult(NonpagedListKeyedBucket aggregations = default(NonpagedListKeyedBucket), PagedListUnitCostLine unitLines = default(PagedListUnitCostLine))
        {
            this.Aggregations = aggregations;
            this.UnitLines = unitLines;
        }
        
        /// <summary>
        /// Gets or Sets Aggregations
        /// </summary>
        [DataMember(Name="aggregations", EmitDefaultValue=false)]
        public NonpagedListKeyedBucket Aggregations { get; set; }

        /// <summary>
        /// Gets or Sets UnitLines
        /// </summary>
        [DataMember(Name="unitLines", EmitDefaultValue=false)]
        public PagedListUnitCostLine UnitLines { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UnitLineSearchResult {\n");
            sb.Append("  Aggregations: ").Append(Aggregations).Append("\n");
            sb.Append("  UnitLines: ").Append(UnitLines).Append("\n");
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
            return this.Equals(input as UnitLineSearchResult);
        }

        /// <summary>
        /// Returns true if UnitLineSearchResult instances are equal
        /// </summary>
        /// <param name="input">Instance of UnitLineSearchResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UnitLineSearchResult input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Aggregations == input.Aggregations ||
                    (this.Aggregations != null &&
                    this.Aggregations.Equals(input.Aggregations))
                ) && 
                (
                    this.UnitLines == input.UnitLines ||
                    (this.UnitLines != null &&
                    this.UnitLines.Equals(input.UnitLines))
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
                if (this.Aggregations != null)
                    hashCode = hashCode * 59 + this.Aggregations.GetHashCode();
                if (this.UnitLines != null)
                    hashCode = hashCode * 59 + this.UnitLines.GetHashCode();
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