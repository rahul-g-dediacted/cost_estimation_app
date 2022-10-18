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
using Newtonsoft.Json.Converters;

namespace Gordian.DataApi.Model
{
    /// <summary>
    /// CommercialBuildingWithToc
    /// </summary>
    [DataContract]
    public partial class CommercialBuildingWithToc :  IEquatable<CommercialBuildingWithToc>, IValidatableObject
    {
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
        /// Defines ModelType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ModelTypeEnum
        {
            
            /// <summary>
            /// Enum Commercial for value: commercial
            /// </summary>
            [EnumMember(Value = "commercial")]
            Commercial = 1,
            
            /// <summary>
            /// Enum Industrial for value: industrial
            /// </summary>
            [EnumMember(Value = "industrial")]
            Industrial = 2,
            
            /// <summary>
            /// Enum Institutional for value: institutional
            /// </summary>
            [EnumMember(Value = "institutional")]
            Institutional = 3
        }

        /// <summary>
        /// Gets or Sets ModelType
        /// </summary>
        [DataMember(Name="modelType", EmitDefaultValue=false)]
        public ModelTypeEnum? ModelType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommercialBuildingWithToc" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="release">release.</param>
        /// <param name="location">location.</param>
        /// <param name="laborType">laborType.</param>
        /// <param name="code">code.</param>
        /// <param name="description">description.</param>
        /// <param name="modelType">modelType.</param>
        /// <param name="modelActivityType">modelActivityType.</param>
        /// <param name="wall">wall.</param>
        /// <param name="renovation">renovation.</param>
        /// <param name="doesModelOfferBasement">doesModelOfferBasement.</param>
        /// <param name="buildingParameters">buildingParameters.</param>
        /// <param name="feesPercent">feesPercent.</param>
        /// <param name="totalNumberOfDaysToComplete">totalNumberOfDaysToComplete.</param>
        /// <param name="monthlyBuildingTocCosts">monthlyBuildingTocCosts.</param>
        /// <param name="monthlyDivisionTocCosts">monthlyDivisionTocCosts.</param>
        /// <param name="buildingTradeUsages">buildingTradeUsages.</param>
        /// <param name="buildingCost">buildingCost.</param>
        /// <param name="requestParameters">requestParameters.</param>
        /// <param name="warningMessages">warningMessages.</param>
        public CommercialBuildingWithToc(string id = default(string), ReferenceRelease release = default(ReferenceRelease), ReferenceLocation location = default(ReferenceLocation), LaborTypeEnum? laborType = default(LaborTypeEnum?), string code = default(string), string description = default(string), ModelTypeEnum? modelType = default(ModelTypeEnum?), string modelActivityType = default(string), Wall wall = default(Wall), Renovation renovation = default(Renovation), bool? doesModelOfferBasement = default(bool?), BuildingParameters buildingParameters = default(BuildingParameters), BuildingFees feesPercent = default(BuildingFees), int? totalNumberOfDaysToComplete = default(int?), List<MonthlyTocCost> monthlyBuildingTocCosts = default(List<MonthlyTocCost>), List<MonthlyDivisionTocCost> monthlyDivisionTocCosts = default(List<MonthlyDivisionTocCost>), List<TradeUsage> buildingTradeUsages = default(List<TradeUsage>), BuildingExtendedCost buildingCost = default(BuildingExtendedCost), BuildingRequestParametersConstructConnect requestParameters = default(BuildingRequestParametersConstructConnect), List<string> warningMessages = default(List<string>))
        {
            this.Id = id;
            this.Release = release;
            this.Location = location;
            this.LaborType = laborType;
            this.Code = code;
            this.Description = description;
            this.ModelType = modelType;
            this.ModelActivityType = modelActivityType;
            this.Wall = wall;
            this.Renovation = renovation;
            this.DoesModelOfferBasement = doesModelOfferBasement;
            this.BuildingParameters = buildingParameters;
            this.FeesPercent = feesPercent;
            this.TotalNumberOfDaysToComplete = totalNumberOfDaysToComplete;
            this.MonthlyBuildingTocCosts = monthlyBuildingTocCosts;
            this.MonthlyDivisionTocCosts = monthlyDivisionTocCosts;
            this.BuildingTradeUsages = buildingTradeUsages;
            this.BuildingCost = buildingCost;
            this.RequestParameters = requestParameters;
            this.WarningMessages = warningMessages;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Release
        /// </summary>
        [DataMember(Name="release", EmitDefaultValue=false)]
        public ReferenceRelease Release { get; set; }

        /// <summary>
        /// Gets or Sets Location
        /// </summary>
        [DataMember(Name="location", EmitDefaultValue=false)]
        public ReferenceLocation Location { get; set; }


        /// <summary>
        /// Gets or Sets Code
        /// </summary>
        [DataMember(Name="code", EmitDefaultValue=false)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }


        /// <summary>
        /// Gets or Sets ModelActivityType
        /// </summary>
        [DataMember(Name="modelActivityType", EmitDefaultValue=false)]
        public string ModelActivityType { get; set; }

        /// <summary>
        /// Gets or Sets Wall
        /// </summary>
        [DataMember(Name="wall", EmitDefaultValue=false)]
        public Wall Wall { get; set; }

        /// <summary>
        /// Gets or Sets Renovation
        /// </summary>
        [DataMember(Name="renovation", EmitDefaultValue=false)]
        public Renovation Renovation { get; set; }

        /// <summary>
        /// Gets or Sets DoesModelOfferBasement
        /// </summary>
        [DataMember(Name="doesModelOfferBasement", EmitDefaultValue=false)]
        public bool? DoesModelOfferBasement { get; set; }

        /// <summary>
        /// Gets or Sets BuildingParameters
        /// </summary>
        [DataMember(Name="buildingParameters", EmitDefaultValue=false)]
        public BuildingParameters BuildingParameters { get; set; }

        /// <summary>
        /// Gets or Sets FeesPercent
        /// </summary>
        [DataMember(Name="feesPercent", EmitDefaultValue=false)]
        public BuildingFees FeesPercent { get; set; }

        /// <summary>
        /// Gets or Sets TotalNumberOfDaysToComplete
        /// </summary>
        [DataMember(Name="totalNumberOfDaysToComplete", EmitDefaultValue=false)]
        public int? TotalNumberOfDaysToComplete { get; set; }

        /// <summary>
        /// Gets or Sets MonthlyBuildingTocCosts
        /// </summary>
        [DataMember(Name="monthlyBuildingTocCosts", EmitDefaultValue=false)]
        public List<MonthlyTocCost> MonthlyBuildingTocCosts { get; set; }

        /// <summary>
        /// Gets or Sets MonthlyDivisionTocCosts
        /// </summary>
        [DataMember(Name="monthlyDivisionTocCosts", EmitDefaultValue=false)]
        public List<MonthlyDivisionTocCost> MonthlyDivisionTocCosts { get; set; }

        /// <summary>
        /// Gets or Sets BuildingTradeUsages
        /// </summary>
        [DataMember(Name="buildingTradeUsages", EmitDefaultValue=false)]
        public List<TradeUsage> BuildingTradeUsages { get; set; }

        /// <summary>
        /// Gets or Sets BuildingCost
        /// </summary>
        [DataMember(Name="buildingCost", EmitDefaultValue=false)]
        public BuildingExtendedCost BuildingCost { get; set; }

        /// <summary>
        /// Gets or Sets Href
        /// </summary>
        [DataMember(Name="href", EmitDefaultValue=false)]
        public string Href { get; private set; }

        /// <summary>
        /// Gets or Sets RequestParameters
        /// </summary>
        [DataMember(Name="requestParameters", EmitDefaultValue=false)]
        public BuildingRequestParametersConstructConnect RequestParameters { get; set; }

        /// <summary>
        /// Gets or Sets WarningMessages
        /// </summary>
        [DataMember(Name="warningMessages", EmitDefaultValue=false)]
        public List<string> WarningMessages { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CommercialBuildingWithToc {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Release: ").Append(Release).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  LaborType: ").Append(LaborType).Append("\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ModelType: ").Append(ModelType).Append("\n");
            sb.Append("  ModelActivityType: ").Append(ModelActivityType).Append("\n");
            sb.Append("  Wall: ").Append(Wall).Append("\n");
            sb.Append("  Renovation: ").Append(Renovation).Append("\n");
            sb.Append("  DoesModelOfferBasement: ").Append(DoesModelOfferBasement).Append("\n");
            sb.Append("  BuildingParameters: ").Append(BuildingParameters).Append("\n");
            sb.Append("  FeesPercent: ").Append(FeesPercent).Append("\n");
            sb.Append("  TotalNumberOfDaysToComplete: ").Append(TotalNumberOfDaysToComplete).Append("\n");
            sb.Append("  MonthlyBuildingTocCosts: ").Append(MonthlyBuildingTocCosts).Append("\n");
            sb.Append("  MonthlyDivisionTocCosts: ").Append(MonthlyDivisionTocCosts).Append("\n");
            sb.Append("  BuildingTradeUsages: ").Append(BuildingTradeUsages).Append("\n");
            sb.Append("  BuildingCost: ").Append(BuildingCost).Append("\n");
            sb.Append("  Href: ").Append(Href).Append("\n");
            sb.Append("  RequestParameters: ").Append(RequestParameters).Append("\n");
            sb.Append("  WarningMessages: ").Append(WarningMessages).Append("\n");
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
            return this.Equals(input as CommercialBuildingWithToc);
        }

        /// <summary>
        /// Returns true if CommercialBuildingWithToc instances are equal
        /// </summary>
        /// <param name="input">Instance of CommercialBuildingWithToc to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CommercialBuildingWithToc input)
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
                    this.Release == input.Release ||
                    (this.Release != null &&
                    this.Release.Equals(input.Release))
                ) && 
                (
                    this.Location == input.Location ||
                    (this.Location != null &&
                    this.Location.Equals(input.Location))
                ) && 
                (
                    this.LaborType == input.LaborType ||
                    (this.LaborType != null &&
                    this.LaborType.Equals(input.LaborType))
                ) && 
                (
                    this.Code == input.Code ||
                    (this.Code != null &&
                    this.Code.Equals(input.Code))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.ModelType == input.ModelType ||
                    (this.ModelType != null &&
                    this.ModelType.Equals(input.ModelType))
                ) && 
                (
                    this.ModelActivityType == input.ModelActivityType ||
                    (this.ModelActivityType != null &&
                    this.ModelActivityType.Equals(input.ModelActivityType))
                ) && 
                (
                    this.Wall == input.Wall ||
                    (this.Wall != null &&
                    this.Wall.Equals(input.Wall))
                ) && 
                (
                    this.Renovation == input.Renovation ||
                    (this.Renovation != null &&
                    this.Renovation.Equals(input.Renovation))
                ) && 
                (
                    this.DoesModelOfferBasement == input.DoesModelOfferBasement ||
                    (this.DoesModelOfferBasement != null &&
                    this.DoesModelOfferBasement.Equals(input.DoesModelOfferBasement))
                ) && 
                (
                    this.BuildingParameters == input.BuildingParameters ||
                    (this.BuildingParameters != null &&
                    this.BuildingParameters.Equals(input.BuildingParameters))
                ) && 
                (
                    this.FeesPercent == input.FeesPercent ||
                    (this.FeesPercent != null &&
                    this.FeesPercent.Equals(input.FeesPercent))
                ) && 
                (
                    this.TotalNumberOfDaysToComplete == input.TotalNumberOfDaysToComplete ||
                    (this.TotalNumberOfDaysToComplete != null &&
                    this.TotalNumberOfDaysToComplete.Equals(input.TotalNumberOfDaysToComplete))
                ) && 
                (
                    this.MonthlyBuildingTocCosts == input.MonthlyBuildingTocCosts ||
                    this.MonthlyBuildingTocCosts != null &&
                    this.MonthlyBuildingTocCosts.SequenceEqual(input.MonthlyBuildingTocCosts)
                ) && 
                (
                    this.MonthlyDivisionTocCosts == input.MonthlyDivisionTocCosts ||
                    this.MonthlyDivisionTocCosts != null &&
                    this.MonthlyDivisionTocCosts.SequenceEqual(input.MonthlyDivisionTocCosts)
                ) && 
                (
                    this.BuildingTradeUsages == input.BuildingTradeUsages ||
                    this.BuildingTradeUsages != null &&
                    this.BuildingTradeUsages.SequenceEqual(input.BuildingTradeUsages)
                ) && 
                (
                    this.BuildingCost == input.BuildingCost ||
                    (this.BuildingCost != null &&
                    this.BuildingCost.Equals(input.BuildingCost))
                ) && 
                (
                    this.Href == input.Href ||
                    (this.Href != null &&
                    this.Href.Equals(input.Href))
                ) && 
                (
                    this.RequestParameters == input.RequestParameters ||
                    (this.RequestParameters != null &&
                    this.RequestParameters.Equals(input.RequestParameters))
                ) && 
                (
                    this.WarningMessages == input.WarningMessages ||
                    this.WarningMessages != null &&
                    this.WarningMessages.SequenceEqual(input.WarningMessages)
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
                if (this.Release != null)
                    hashCode = hashCode * 59 + this.Release.GetHashCode();
                if (this.Location != null)
                    hashCode = hashCode * 59 + this.Location.GetHashCode();
                if (this.LaborType != null)
                    hashCode = hashCode * 59 + this.LaborType.GetHashCode();
                if (this.Code != null)
                    hashCode = hashCode * 59 + this.Code.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.ModelType != null)
                    hashCode = hashCode * 59 + this.ModelType.GetHashCode();
                if (this.ModelActivityType != null)
                    hashCode = hashCode * 59 + this.ModelActivityType.GetHashCode();
                if (this.Wall != null)
                    hashCode = hashCode * 59 + this.Wall.GetHashCode();
                if (this.Renovation != null)
                    hashCode = hashCode * 59 + this.Renovation.GetHashCode();
                if (this.DoesModelOfferBasement != null)
                    hashCode = hashCode * 59 + this.DoesModelOfferBasement.GetHashCode();
                if (this.BuildingParameters != null)
                    hashCode = hashCode * 59 + this.BuildingParameters.GetHashCode();
                if (this.FeesPercent != null)
                    hashCode = hashCode * 59 + this.FeesPercent.GetHashCode();
                if (this.TotalNumberOfDaysToComplete != null)
                    hashCode = hashCode * 59 + this.TotalNumberOfDaysToComplete.GetHashCode();
                if (this.MonthlyBuildingTocCosts != null)
                    hashCode = hashCode * 59 + this.MonthlyBuildingTocCosts.GetHashCode();
                if (this.MonthlyDivisionTocCosts != null)
                    hashCode = hashCode * 59 + this.MonthlyDivisionTocCosts.GetHashCode();
                if (this.BuildingTradeUsages != null)
                    hashCode = hashCode * 59 + this.BuildingTradeUsages.GetHashCode();
                if (this.BuildingCost != null)
                    hashCode = hashCode * 59 + this.BuildingCost.GetHashCode();
                if (this.Href != null)
                    hashCode = hashCode * 59 + this.Href.GetHashCode();
                if (this.RequestParameters != null)
                    hashCode = hashCode * 59 + this.RequestParameters.GetHashCode();
                if (this.WarningMessages != null)
                    hashCode = hashCode * 59 + this.WarningMessages.GetHashCode();
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
