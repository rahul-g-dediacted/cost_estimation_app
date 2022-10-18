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
    /// BuildingCost
    /// </summary>
    [DataContract]
    public partial class BuildingCost :  IEquatable<BuildingCost>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingCost" /> class.
        /// </summary>
        /// <param name="subtotal">subtotal.</param>
        /// <param name="contractorFees">contractorFees.</param>
        /// <param name="architecturalFees">architecturalFees.</param>
        /// <param name="userFees">userFees.</param>
        /// <param name="total">total.</param>
        public BuildingCost(DetailedCost subtotal = default(DetailedCost), DetailedCost contractorFees = default(DetailedCost), DetailedCost architecturalFees = default(DetailedCost), DetailedCost userFees = default(DetailedCost), DetailedCost total = default(DetailedCost))
        {
            this.Subtotal = subtotal;
            this.ContractorFees = contractorFees;
            this.ArchitecturalFees = architecturalFees;
            this.UserFees = userFees;
            this.Total = total;
        }
        
        /// <summary>
        /// Gets or Sets Subtotal
        /// </summary>
        [DataMember(Name="subtotal", EmitDefaultValue=false)]
        public DetailedCost Subtotal { get; set; }

        /// <summary>
        /// Gets or Sets ContractorFees
        /// </summary>
        [DataMember(Name="contractorFees", EmitDefaultValue=false)]
        public DetailedCost ContractorFees { get; set; }

        /// <summary>
        /// Gets or Sets ArchitecturalFees
        /// </summary>
        [DataMember(Name="architecturalFees", EmitDefaultValue=false)]
        public DetailedCost ArchitecturalFees { get; set; }

        /// <summary>
        /// Gets or Sets UserFees
        /// </summary>
        [DataMember(Name="userFees", EmitDefaultValue=false)]
        public DetailedCost UserFees { get; set; }

        /// <summary>
        /// Gets or Sets Total
        /// </summary>
        [DataMember(Name="total", EmitDefaultValue=false)]
        public DetailedCost Total { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BuildingCost {\n");
            sb.Append("  Subtotal: ").Append(Subtotal).Append("\n");
            sb.Append("  ContractorFees: ").Append(ContractorFees).Append("\n");
            sb.Append("  ArchitecturalFees: ").Append(ArchitecturalFees).Append("\n");
            sb.Append("  UserFees: ").Append(UserFees).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
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
            return this.Equals(input as BuildingCost);
        }

        /// <summary>
        /// Returns true if BuildingCost instances are equal
        /// </summary>
        /// <param name="input">Instance of BuildingCost to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BuildingCost input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Subtotal == input.Subtotal ||
                    (this.Subtotal != null &&
                    this.Subtotal.Equals(input.Subtotal))
                ) && 
                (
                    this.ContractorFees == input.ContractorFees ||
                    (this.ContractorFees != null &&
                    this.ContractorFees.Equals(input.ContractorFees))
                ) && 
                (
                    this.ArchitecturalFees == input.ArchitecturalFees ||
                    (this.ArchitecturalFees != null &&
                    this.ArchitecturalFees.Equals(input.ArchitecturalFees))
                ) && 
                (
                    this.UserFees == input.UserFees ||
                    (this.UserFees != null &&
                    this.UserFees.Equals(input.UserFees))
                ) && 
                (
                    this.Total == input.Total ||
                    (this.Total != null &&
                    this.Total.Equals(input.Total))
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
                if (this.Subtotal != null)
                    hashCode = hashCode * 59 + this.Subtotal.GetHashCode();
                if (this.ContractorFees != null)
                    hashCode = hashCode * 59 + this.ContractorFees.GetHashCode();
                if (this.ArchitecturalFees != null)
                    hashCode = hashCode * 59 + this.ArchitecturalFees.GetHashCode();
                if (this.UserFees != null)
                    hashCode = hashCode * 59 + this.UserFees.GetHashCode();
                if (this.Total != null)
                    hashCode = hashCode * 59 + this.Total.GetHashCode();
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