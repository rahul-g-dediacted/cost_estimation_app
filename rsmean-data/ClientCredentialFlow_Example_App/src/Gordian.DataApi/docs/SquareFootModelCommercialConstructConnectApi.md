# Gordian.DataApi.Api.SquareFootModelCommercialConstructConnectApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SquarefootmodelCommercialConstructConnectCostByModelIdGet**](SquareFootModelCommercialConstructConnectApi.md#squarefootmodelcommercialconstructconnectcostbymodelidget) | **GET** /v1/squarefootmodel/commercial/constructconnect/cost/{modelId} | Gets a square foot model estimate and labor hours, summarized at the Level 3 and Total Model, based on model and wall/framing type.
[**SquarefootmodelCommercialConstructConnectGet**](SquareFootModelCommercialConstructConnectApi.md#squarefootmodelcommercialconstructconnectget) | **GET** /v1/squarefootmodel/commercial/constructconnect | Get ConstructConnect Models by year
[**SquarefootmodelCommercialConstructConnectTocByModelIdGet**](SquareFootModelCommercialConstructConnectApi.md#squarefootmodelcommercialconstructconnecttocbymodelidget) | **GET** /v1/squarefootmodel/commercial/constructconnect/toc/{modelId} | Gets a square foot model estimate and labor hours with schedule of construction, summarized at the Level 3 and Total Model, based on model and wall/framing type.


<a name="squarefootmodelcommercialconstructconnectcostbymodelidget"></a>
# **SquarefootmodelCommercialConstructConnectCostByModelIdGet**
> CommercialBuildingWithExtendedCost SquarefootmodelCommercialConstructConnectCostByModelIdGet (string modelId, double? totalDollarAmount = null, double? area = null, string renovationLevel = null, string locationId = null, string laborType = null, bool? includeBasement = null)

Gets a square foot model estimate and labor hours, summarized at the Level 3 and Total Model, based on model and wall/framing type.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class SquarefootmodelCommercialConstructConnectCostByModelIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SquareFootModelCommercialConstructConnectApi();
            var modelId = modelId_example;  // string | The model Id, for example 2017-001.
            var totalDollarAmount = 1.2;  // double? | The total dollar amount of the building. (optional) 
            var area = 1.2;  // double? | The area of the building (S.F.). (optional) 
            var renovationLevel = renovationLevel_example;  // string | The 2-digit renovation level code. Eg. 01 (optional) 
            var locationId = locationId_example;  // string | The location identifier for computing localized costs. Defaults to US National Average (us-us-national). (optional) 
            var laborType = laborType_example;  // string | Specifies standard union or open shop unit lines. Defaults to standard union (std). (optional) 
            var includeBasement = true;  // bool? | Specifies if basement is includeded. Default to false. (optional) 

            try
            {
                // Gets a square foot model estimate and labor hours, summarized at the Level 3 and Total Model, based on model and wall/framing type.
                CommercialBuildingWithExtendedCost result = apiInstance.SquarefootmodelCommercialConstructConnectCostByModelIdGet(modelId, totalDollarAmount, area, renovationLevel, locationId, laborType, includeBasement);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SquareFootModelCommercialConstructConnectApi.SquarefootmodelCommercialConstructConnectCostByModelIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modelId** | **string**| The model Id, for example 2017-001. | 
 **totalDollarAmount** | **double?**| The total dollar amount of the building. | [optional] 
 **area** | **double?**| The area of the building (S.F.). | [optional] 
 **renovationLevel** | **string**| The 2-digit renovation level code. Eg. 01 | [optional] 
 **locationId** | **string**| The location identifier for computing localized costs. Defaults to US National Average (us-us-national). | [optional] 
 **laborType** | **string**| Specifies standard union or open shop unit lines. Defaults to standard union (std). | [optional] 
 **includeBasement** | **bool?**| Specifies if basement is includeded. Default to false. | [optional] 

### Return type

[**CommercialBuildingWithExtendedCost**](CommercialBuildingWithExtendedCost.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="squarefootmodelcommercialconstructconnectget"></a>
# **SquarefootmodelCommercialConstructConnectGet**
> NonpagedListCommercialBuildingTypeWithRenovations SquarefootmodelCommercialConstructConnectGet (string releaseYear = null, string searchTerm = null)

Get ConstructConnect Models by year

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class SquarefootmodelCommercialConstructConnectGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SquareFootModelCommercialConstructConnectApi();
            var releaseYear = releaseYear_example;  // string |  (optional) 
            var searchTerm = searchTerm_example;  // string |  (optional) 

            try
            {
                // Get ConstructConnect Models by year
                NonpagedListCommercialBuildingTypeWithRenovations result = apiInstance.SquarefootmodelCommercialConstructConnectGet(releaseYear, searchTerm);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SquareFootModelCommercialConstructConnectApi.SquarefootmodelCommercialConstructConnectGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **releaseYear** | **string**|  | [optional] 
 **searchTerm** | **string**|  | [optional] 

### Return type

[**NonpagedListCommercialBuildingTypeWithRenovations**](NonpagedListCommercialBuildingTypeWithRenovations.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="squarefootmodelcommercialconstructconnecttocbymodelidget"></a>
# **SquarefootmodelCommercialConstructConnectTocByModelIdGet**
> CommercialBuildingWithToc SquarefootmodelCommercialConstructConnectTocByModelIdGet (string modelId, double? totalDollarAmount = null, double? area = null, string renovationLevel = null, DateTime? constructionStartDate = null, string locationId = null, string laborType = null, bool? includeBasement = null)

Gets a square foot model estimate and labor hours with schedule of construction, summarized at the Level 3 and Total Model, based on model and wall/framing type.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class SquarefootmodelCommercialConstructConnectTocByModelIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SquareFootModelCommercialConstructConnectApi();
            var modelId = modelId_example;  // string | The model Id, for example 2017-001.
            var totalDollarAmount = 1.2;  // double? | The total dollar amount of the building. (optional) 
            var area = 1.2;  // double? | The area of the building (S.F.). (optional) 
            var renovationLevel = renovationLevel_example;  // string | The 2-digit renovation level code. Eg. 01 (optional) 
            var constructionStartDate = 2013-10-20T19:20:30+01:00;  // DateTime? | Specifies the construction start date. (optional) 
            var locationId = locationId_example;  // string | The location identifier for computing localized costs. Defaults to US National Average (us-us-national). (optional) 
            var laborType = laborType_example;  // string | Specifies standard union or open shop unit lines. Defaults to standard union (std). (optional) 
            var includeBasement = true;  // bool? | Specifies if basement is includeded. Default to false. (optional) 

            try
            {
                // Gets a square foot model estimate and labor hours with schedule of construction, summarized at the Level 3 and Total Model, based on model and wall/framing type.
                CommercialBuildingWithToc result = apiInstance.SquarefootmodelCommercialConstructConnectTocByModelIdGet(modelId, totalDollarAmount, area, renovationLevel, constructionStartDate, locationId, laborType, includeBasement);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SquareFootModelCommercialConstructConnectApi.SquarefootmodelCommercialConstructConnectTocByModelIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **modelId** | **string**| The model Id, for example 2017-001. | 
 **totalDollarAmount** | **double?**| The total dollar amount of the building. | [optional] 
 **area** | **double?**| The area of the building (S.F.). | [optional] 
 **renovationLevel** | **string**| The 2-digit renovation level code. Eg. 01 | [optional] 
 **constructionStartDate** | **DateTime?**| Specifies the construction start date. | [optional] 
 **locationId** | **string**| The location identifier for computing localized costs. Defaults to US National Average (us-us-national). | [optional] 
 **laborType** | **string**| Specifies standard union or open shop unit lines. Defaults to standard union (std). | [optional] 
 **includeBasement** | **bool?**| Specifies if basement is includeded. Default to false. | [optional] 

### Return type

[**CommercialBuildingWithToc**](CommercialBuildingWithToc.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

