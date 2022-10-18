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
    /// EquipmentRentalCosts
    /// </summary>
    [DataContract]
    public partial class EquipmentRentalCosts :  IEquatable<EquipmentRentalCosts>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentRentalCosts" /> class.
        /// </summary>
        /// <param name="rentPerDay">rentPerDay.</param>
        /// <param name="rentPerWeek">rentPerWeek.</param>
        /// <param name="rentPerMonth">rentPerMonth.</param>
        /// <param name="hourlyOperatingCost">hourlyOperatingCost.</param>
        /// <param name="dailyCost">dailyCost.</param>
        /// <param name="weeklyCost">weeklyCost.</param>
        /// <param name="monthlyCost">monthlyCost.</param>
        /// <param name="dailyCostOp">dailyCostOp.</param>
        /// <param name="weeklyCostOp">weeklyCostOp.</param>
        /// <param name="monthlyCostOp">monthlyCostOp.</param>
        public EquipmentRentalCosts(double? rentPerDay = default(double?), double? rentPerWeek = default(double?), double? rentPerMonth = default(double?), double? hourlyOperatingCost = default(double?), double? dailyCost = default(double?), double? weeklyCost = default(double?), double? monthlyCost = default(double?), double? dailyCostOp = default(double?), double? weeklyCostOp = default(double?), double? monthlyCostOp = default(double?))
        {
            this.RentPerDay = rentPerDay;
            this.RentPerWeek = rentPerWeek;
            this.RentPerMonth = rentPerMonth;
            this.HourlyOperatingCost = hourlyOperatingCost;
            this.DailyCost = dailyCost;
            this.WeeklyCost = weeklyCost;
            this.MonthlyCost = monthlyCost;
            this.DailyCostOp = dailyCostOp;
            this.WeeklyCostOp = weeklyCostOp;
            this.MonthlyCostOp = monthlyCostOp;
        }
        
        /// <summary>
        /// Gets or Sets RentPerDay
        /// </summary>
        [DataMember(Name="rentPerDay", EmitDefaultValue=false)]
        public double? RentPerDay { get; set; }

        /// <summary>
        /// Gets or Sets RentPerWeek
        /// </summary>
        [DataMember(Name="rentPerWeek", EmitDefaultValue=false)]
        public double? RentPerWeek { get; set; }

        /// <summary>
        /// Gets or Sets RentPerMonth
        /// </summary>
        [DataMember(Name="rentPerMonth", EmitDefaultValue=false)]
        public double? RentPerMonth { get; set; }

        /// <summary>
        /// Gets or Sets HourlyOperatingCost
        /// </summary>
        [DataMember(Name="hourlyOperatingCost", EmitDefaultValue=false)]
        public double? HourlyOperatingCost { get; set; }

        /// <summary>
        /// Gets or Sets DailyCost
        /// </summary>
        [DataMember(Name="dailyCost", EmitDefaultValue=false)]
        public double? DailyCost { get; set; }

        /// <summary>
        /// Gets or Sets WeeklyCost
        /// </summary>
        [DataMember(Name="weeklyCost", EmitDefaultValue=false)]
        public double? WeeklyCost { get; set; }

        /// <summary>
        /// Gets or Sets MonthlyCost
        /// </summary>
        [DataMember(Name="monthlyCost", EmitDefaultValue=false)]
        public double? MonthlyCost { get; set; }

        /// <summary>
        /// Gets or Sets DailyCostOp
        /// </summary>
        [DataMember(Name="dailyCostOp", EmitDefaultValue=false)]
        public double? DailyCostOp { get; set; }

        /// <summary>
        /// Gets or Sets WeeklyCostOp
        /// </summary>
        [DataMember(Name="weeklyCostOp", EmitDefaultValue=false)]
        public double? WeeklyCostOp { get; set; }

        /// <summary>
        /// Gets or Sets MonthlyCostOp
        /// </summary>
        [DataMember(Name="monthlyCostOp", EmitDefaultValue=false)]
        public double? MonthlyCostOp { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EquipmentRentalCosts {\n");
            sb.Append("  RentPerDay: ").Append(RentPerDay).Append("\n");
            sb.Append("  RentPerWeek: ").Append(RentPerWeek).Append("\n");
            sb.Append("  RentPerMonth: ").Append(RentPerMonth).Append("\n");
            sb.Append("  HourlyOperatingCost: ").Append(HourlyOperatingCost).Append("\n");
            sb.Append("  DailyCost: ").Append(DailyCost).Append("\n");
            sb.Append("  WeeklyCost: ").Append(WeeklyCost).Append("\n");
            sb.Append("  MonthlyCost: ").Append(MonthlyCost).Append("\n");
            sb.Append("  DailyCostOp: ").Append(DailyCostOp).Append("\n");
            sb.Append("  WeeklyCostOp: ").Append(WeeklyCostOp).Append("\n");
            sb.Append("  MonthlyCostOp: ").Append(MonthlyCostOp).Append("\n");
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
            return this.Equals(input as EquipmentRentalCosts);
        }

        /// <summary>
        /// Returns true if EquipmentRentalCosts instances are equal
        /// </summary>
        /// <param name="input">Instance of EquipmentRentalCosts to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EquipmentRentalCosts input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.RentPerDay == input.RentPerDay ||
                    (this.RentPerDay != null &&
                    this.RentPerDay.Equals(input.RentPerDay))
                ) && 
                (
                    this.RentPerWeek == input.RentPerWeek ||
                    (this.RentPerWeek != null &&
                    this.RentPerWeek.Equals(input.RentPerWeek))
                ) && 
                (
                    this.RentPerMonth == input.RentPerMonth ||
                    (this.RentPerMonth != null &&
                    this.RentPerMonth.Equals(input.RentPerMonth))
                ) && 
                (
                    this.HourlyOperatingCost == input.HourlyOperatingCost ||
                    (this.HourlyOperatingCost != null &&
                    this.HourlyOperatingCost.Equals(input.HourlyOperatingCost))
                ) && 
                (
                    this.DailyCost == input.DailyCost ||
                    (this.DailyCost != null &&
                    this.DailyCost.Equals(input.DailyCost))
                ) && 
                (
                    this.WeeklyCost == input.WeeklyCost ||
                    (this.WeeklyCost != null &&
                    this.WeeklyCost.Equals(input.WeeklyCost))
                ) && 
                (
                    this.MonthlyCost == input.MonthlyCost ||
                    (this.MonthlyCost != null &&
                    this.MonthlyCost.Equals(input.MonthlyCost))
                ) && 
                (
                    this.DailyCostOp == input.DailyCostOp ||
                    (this.DailyCostOp != null &&
                    this.DailyCostOp.Equals(input.DailyCostOp))
                ) && 
                (
                    this.WeeklyCostOp == input.WeeklyCostOp ||
                    (this.WeeklyCostOp != null &&
                    this.WeeklyCostOp.Equals(input.WeeklyCostOp))
                ) && 
                (
                    this.MonthlyCostOp == input.MonthlyCostOp ||
                    (this.MonthlyCostOp != null &&
                    this.MonthlyCostOp.Equals(input.MonthlyCostOp))
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
                if (this.RentPerDay != null)
                    hashCode = hashCode * 59 + this.RentPerDay.GetHashCode();
                if (this.RentPerWeek != null)
                    hashCode = hashCode * 59 + this.RentPerWeek.GetHashCode();
                if (this.RentPerMonth != null)
                    hashCode = hashCode * 59 + this.RentPerMonth.GetHashCode();
                if (this.HourlyOperatingCost != null)
                    hashCode = hashCode * 59 + this.HourlyOperatingCost.GetHashCode();
                if (this.DailyCost != null)
                    hashCode = hashCode * 59 + this.DailyCost.GetHashCode();
                if (this.WeeklyCost != null)
                    hashCode = hashCode * 59 + this.WeeklyCost.GetHashCode();
                if (this.MonthlyCost != null)
                    hashCode = hashCode * 59 + this.MonthlyCost.GetHashCode();
                if (this.DailyCostOp != null)
                    hashCode = hashCode * 59 + this.DailyCostOp.GetHashCode();
                if (this.WeeklyCostOp != null)
                    hashCode = hashCode * 59 + this.WeeklyCostOp.GetHashCode();
                if (this.MonthlyCostOp != null)
                    hashCode = hashCode * 59 + this.MonthlyCostOp.GetHashCode();
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
