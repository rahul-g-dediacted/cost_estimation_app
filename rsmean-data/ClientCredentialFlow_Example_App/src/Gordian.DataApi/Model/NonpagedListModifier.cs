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

namespace Gordian.DataApi.Model
{
    /// <summary>
    /// NonpagedListModifier
    /// </summary>
    [DataContract]
    public partial class NonpagedListModifier :  IEquatable<NonpagedListModifier>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonpagedListModifier" /> class.
        /// </summary>
        /// <param name="recordCount">recordCount.</param>
        /// <param name="items">items.</param>
        public NonpagedListModifier(int? recordCount = default(int?), List<Modifier> items = default(List<Modifier>))
        {
            this.RecordCount = recordCount;
            this.Items = items;
        }
        
        /// <summary>
        /// Gets or Sets RecordCount
        /// </summary>
        [DataMember(Name="recordCount", EmitDefaultValue=false)]
        public int? RecordCount { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>
        [DataMember(Name="items", EmitDefaultValue=false)]
        public List<Modifier> Items { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NonpagedListModifier {\n");
            sb.Append("  RecordCount: ").Append(RecordCount).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
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
            return this.Equals(input as NonpagedListModifier);
        }

        /// <summary>
        /// Returns true if NonpagedListModifier instances are equal
        /// </summary>
        /// <param name="input">Instance of NonpagedListModifier to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NonpagedListModifier input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.RecordCount == input.RecordCount ||
                    (this.RecordCount != null &&
                    this.RecordCount.Equals(input.RecordCount))
                ) && 
                (
                    this.Items == input.Items ||
                    this.Items != null &&
                    this.Items.SequenceEqual(input.Items)
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
                if (this.RecordCount != null)
                    hashCode = hashCode * 59 + this.RecordCount.GetHashCode();
                if (this.Items != null)
                    hashCode = hashCode * 59 + this.Items.GetHashCode();
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
