# Gordian.DataApi.Api.SquareFootModelCommercialModelEstimatesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SquarefootmodelCommercialModelEstimatesByModelIdwallCodeGet**](SquareFootModelCommercialModelEstimatesApi.md#squarefootmodelcommercialmodelestimatesbymodelidwallcodeget) | **GET** /v1/squarefootmodel/commercial/modelestimates/{modelId}-{wallCode} | Gets a model estimate by model Id, wall code, and other parameters.
[**SquarefootmodelCommercialModelEstimatesByModelIdwallCodePost**](SquareFootModelCommercialModelEstimatesApi.md#squarefootmodelcommercialmodelestimatesbymodelidwallcodepost) | **POST** /v1/squarefootmodel/commercial/modelestimates/{modelId}-{wallCode} | Gets a customized model estimate by specifying assembly lines to add, update, or delete.


<a name="squarefootmodelcommercialmodelestimatesbymodelidwallcodeget"></a>
# **SquarefootmodelCommercialModelEstimatesByModelIdwallCodeGet**
> CommercialBuilding SquarefootmodelCommercialModelEstimatesByModelIdwallCodeGet (string modelId, string wallCode, string releaseId = null, string locationId = null, string laborType = null, double? area = null, double? perimeter = null, double? stories = null, double? storyHeight = null, bool? includeBasement = null, double? contractorFees = null, double? architecturalFees = null, double? userFees = null)

Gets a model estimate by model Id, wall code, and other parameters.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class SquarefootmodelCommercialModelEstimatesByModelIdwallCodeGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SquareFootModelCommercialModelEstimatesApi();
            var modelId = modelId_example;  // string | The model Id, for example 2017-001.
            var wallCode = wallCode_example;  // string | The wall code.
            var releaseId = releaseId_example;  // string | The release identifier. Defaults to the most recent annual release. (optional) 
            var locationId = locationId_example;  // string | The location identifier for computing localized costs. Defaults to US National Average (us-us-national). (optional) 
            var laborType = laborType_example;  // string | Specifies standard union or open shop unit lines. Defaults to standard union (std). (optional) 
            var area = 1.2;  // double? | Area of the building (S.F.). Model default will be used if not provided. (optional) 
            var perimeter = 1.2;  // double? | Perimeter of the building (L.F.). Model default will be used if not provided. (optional) 
            var stories = 1.2;  // double? | Stories of the building. Model default will be used if not provided. (optional) 
            var storyHeight = 1.2;  // double? | Story height of the building (L.F.). Model default will be used if not provided. (optional) 
            var includeBasement = true;  // bool? | Specifies if basement is includeded. Default to false. (optional) 
            var contractorFees = 1.2;  // double? | Contractor fees by percentage. Model default will be used if not provided. (optional) 
            var architecturalFees = 1.2;  // double? | Architectural fees by percentage. Model default will be used if not provided. (optional) 
            var userFees = 1.2;  // double? | User fees by percentage. Model default will be used if not provided. (optional) 

            try
            {
                // Gets a model estimate by model Id, wall code, and other parameters.
                CommercialBuilding result = apiInstance.SquarefootmodelCommercialModelEstimatesByModelIdwallCodeGet(modelId, wallCode, releaseId, locationId, laborType, area, perimeter, stories, storyHeight, includeBasement, contractorFees, architecturalFees, userFees);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SquareFootModelCommercialModelEstimatesApi.SquarefootmodelCommercialModelEstimatesByModelIdwallCodeGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modelId** | **string**| The model Id, for example 2017-001. | 
 **wallCode** | **string**| The wall code. | 
 **releaseId** | **string**| The release identifier. Defaults to the most recent annual release. | [optional] 
 **locationId** | **string**| The location identifier for computing localized costs. Defaults to US National Average (us-us-national). | [optional] 
 **laborType** | **string**| Specifies standard union or open shop unit lines. Defaults to standard union (std). | [optional] 
 **area** | **double?**| Area of the building (S.F.). Model default will be used if not provided. | [optional] 
 **perimeter** | **double?**| Perimeter of the building (L.F.). Model default will be used if not provided. | [optional] 
 **stories** | **double?**| Stories of the building. Model default will be used if not provided. | [optional] 
 **storyHeight** | **double?**| Story height of the building (L.F.). Model default will be used if not provided. | [optional] 
 **includeBasement** | **bool?**| Specifies if basement is includeded. Default to false. | [optional] 
 **contractorFees** | **double?**| Contractor fees by percentage. Model default will be used if not provided. | [optional] 
 **architecturalFees** | **double?**| Architectural fees by percentage. Model default will be used if not provided. | [optional] 
 **userFees** | **double?**| User fees by percentage. Model default will be used if not provided. | [optional] 

### Return type

[**CommercialBuilding**](CommercialBuilding.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="squarefootmodelcommercialmodelestimatesbymodelidwallcodepost"></a>
# **SquarefootmodelCommercialModelEstimatesByModelIdwallCodePost**
> CommercialBuilding SquarefootmodelCommercialModelEstimatesByModelIdwallCodePost (string modelId, string wallCode, string releaseId = null, string locationId = null, string laborType = null, double? area = null, double? perimeter = null, double? stories = null, double? storyHeight = null, bool? includeBasement = null, double? contractorFees = null, double? architecturalFees = null, double? userFees = null, List<CustomizationRequest> assemblyLineCustomizations = null)

Gets a customized model estimate by specifying assembly lines to add, update, or delete.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class SquarefootmodelCommercialModelEstimatesByModelIdwallCodePostExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SquareFootModelCommercialModelEstimatesApi();
            var modelId = modelId_example;  // string | The model Id, for example, 2017-001.
            var wallCode = wallCode_example;  // string | The wall code.
            var releaseId = releaseId_example;  // string | The release identifier. Defaults to the most recent annual release. (optional) 
            var locationId = locationId_example;  // string | The location identifier for computing localized costs. Defaults to US National Average (us-us-national). (optional) 
            var laborType = laborType_example;  // string | Specifies standard union or open shop unit lines. Defaults to standard union (std). (optional) 
            var area = 1.2;  // double? | Area of the building (S.F.). Model default will be used if not provided. (optional) 
            var perimeter = 1.2;  // double? | Perimeter of the building (L.F.). Model default will be used if not provided. (optional) 
            var stories = 1.2;  // double? | Stories of the building. Model default will be used if not provided. (optional) 
            var storyHeight = 1.2;  // double? | Story height of the building (L.F.). Model default will be used if not provided. (optional) 
            var includeBasement = true;  // bool? | Specifies whether or not to include basement in the estimate. Defaults to false. (optional) 
            var contractorFees = 1.2;  // double? | Contractor fees by percentage. Model default will be used if not provided. (optional) 
            var architecturalFees = 1.2;  // double? | Architectural fees by percentage. Model default will be used if not provided. (optional) 
            var userFees = 1.2;  // double? | User fees by percentage. Model default will be used if not provided. (optional) 
            var assemblyLineCustomizations = new List<CustomizationRequest>(); // List<CustomizationRequest> | Use this to customize the estimate by specifying assembly lines to add, update or delete. Valid swap action types are \"add\", \"update\" or \"delete\". (optional) 

            try
            {
                // Gets a customized model estimate by specifying assembly lines to add, update, or delete.
                CommercialBuilding result = apiInstance.SquarefootmodelCommercialModelEstimatesByModelIdwallCodePost(modelId, wallCode, releaseId, locationId, laborType, area, perimeter, stories, storyHeight, includeBasement, contractorFees, architecturalFees, userFees, assemblyLineCustomizations);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SquareFootModelCommercialModelEstimatesApi.SquarefootmodelCommercialModelEstimatesByModelIdwallCodePost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modelId** | **string**| The model Id, for example, 2017-001. | 
 **wallCode** | **string**| The wall code. | 
 **releaseId** | **string**| The release identifier. Defaults to the most recent annual release. | [optional] 
 **locationId** | **string**| The location identifier for computing localized costs. Defaults to US National Average (us-us-national). | [optional] 
 **laborType** | **string**| Specifies standard union or open shop unit lines. Defaults to standard union (std). | [optional] 
 **area** | **double?**| Area of the building (S.F.). Model default will be used if not provided. | [optional] 
 **perimeter** | **double?**| Perimeter of the building (L.F.). Model default will be used if not provided. | [optional] 
 **stories** | **double?**| Stories of the building. Model default will be used if not provided. | [optional] 
 **storyHeight** | **double?**| Story height of the building (L.F.). Model default will be used if not provided. | [optional] 
 **includeBasement** | **bool?**| Specifies whether or not to include basement in the estimate. Defaults to false. | [optional] 
 **contractorFees** | **double?**| Contractor fees by percentage. Model default will be used if not provided. | [optional] 
 **architecturalFees** | **double?**| Architectural fees by percentage. Model default will be used if not provided. | [optional] 
 **userFees** | **double?**| User fees by percentage. Model default will be used if not provided. | [optional] 
 **assemblyLineCustomizations** | [**List&lt;CustomizationRequest&gt;**](CustomizationRequest.md)| Use this to customize the estimate by specifying assembly lines to add, update or delete. Valid swap action types are \&quot;add\&quot;, \&quot;update\&quot; or \&quot;delete\&quot;. | [optional] 

### Return type

[**CommercialBuilding**](CommercialBuilding.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

