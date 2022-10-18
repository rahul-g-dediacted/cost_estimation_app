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
    /// PagedListGlobalModifier
    /// </summary>
    [DataContract]
    public partial class PagedListGlobalModifier :  IEquatable<PagedListGlobalModifier>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListGlobalModifier" /> class.
        /// </summary>
        /// <param name="offset">The offset..</param>
        /// <param name="limit">The limit..</param>
        /// <param name="recordCount">The record count..</param>
        /// <param name="items">The items..</param>
        public PagedListGlobalModifier(int? offset = default(int?), int? limit = default(int?), long? recordCount = default(long?), List<GlobalModifier> items = default(List<GlobalModifier>))
        {
            this.Offset = offset;
            this.Limit = limit;
            this.RecordCount = recordCount;
            this.Items = items;
        }
        
        /// <summary>
        /// The offset.
        /// </summary>
        /// <value>The offset.</value>
        [DataMember(Name="offset", EmitDefaultValue=false)]
        public int? Offset { get; set; }

        /// <summary>
        /// The limit.
        /// </summary>
        /// <value>The limit.</value>
        [DataMember(Name="limit", EmitDefaultValue=false)]
        public int? Limit { get; set; }

        /// <summary>
        /// The record count.
        /// </summary>
        /// <value>The record count.</value>
        [DataMember(Name="recordCount", EmitDefaultValue=false)]
        public long? RecordCount { get; set; }

        /// <summary>
        /// The items.
        /// </summary>
        /// <value>The items.</value>
        [DataMember(Name="items", EmitDefaultValue=false)]
        public List<GlobalModifier> Items { get; set; }

        /// <summary>
        /// Gets or Sets PageNavigation
        /// </summary>
        [DataMember(Name="pageNavigation", EmitDefaultValue=false)]
        public PageNavigation PageNavigation { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PagedListGlobalModifier {\n");
            sb.Append("  Offset: ").Append(Offset).Append("\n");
            sb.Append("  Limit: ").Append(Limit).Append("\n");
            sb.Append("  RecordCount: ").Append(RecordCount).Append("\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  PageNavigation: ").Append(PageNavigation).Append("\n");
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
            return this.Equals(input as PagedListGlobalModifier);
        }

        /// <summary>
        /// Returns true if PagedListGlobalModifier instances are equal
        /// </summary>
        /// <param name="input">Instance of PagedListGlobalModifier to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PagedListGlobalModifier input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Offset == input.Offset ||
                    (this.Offset != null &&
                    this.Offset.Equals(input.Offset))
                ) && 
                (
                    this.Limit == input.Limit ||
                    (this.Limit != null &&
                    this.Limit.Equals(input.Limit))
                ) && 
                (
                    this.RecordCount == input.RecordCount ||
                    (this.RecordCount != null &&
                    this.RecordCount.Equals(input.RecordCount))
                ) && 
                (
                    this.Items == input.Items ||
                    this.Items != null &&
                    this.Items.SequenceEqual(input.Items)
                ) && 
                (
                    this.PageNavigation == input.PageNavigation ||
                    (this.PageNavigation != null &&
                    this.PageNavigation.Equals(input.PageNavigation))
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
                if (this.Offset != null)
                    hashCode = hashCode * 59 + this.Offset.GetHashCode();
                if (this.Limit != null)
                    hashCode = hashCode * 59 + this.Limit.GetHashCode();
                if (this.RecordCount != null)
                    hashCode = hashCode * 59 + this.RecordCount.GetHashCode();
                if (this.Items != null)
                    hashCode = hashCode * 59 + this.Items.GetHashCode();
                if (this.PageNavigation != null)
                    hashCode = hashCode * 59 + this.PageNavigation.GetHashCode();
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
