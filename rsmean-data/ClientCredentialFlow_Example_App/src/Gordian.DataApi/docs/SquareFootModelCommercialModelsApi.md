# Gordian.DataApi.Api.SquareFootModelCommercialModelsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SquarefootmodelCommercialModelsByIdGet**](SquareFootModelCommercialModelsApi.md#squarefootmodelcommercialmodelsbyidget) | **GET** /v1/squarefootmodel/commercial/models/{id} | Gets a commercial model by Id.
[**SquarefootmodelCommercialModelsGet**](SquareFootModelCommercialModelsApi.md#squarefootmodelcommercialmodelsget) | **GET** /v1/squarefootmodel/commercial/models | Gets a list of commercial models.


<a name="squarefootmodelcommercialmodelsbyidget"></a>
# **SquarefootmodelCommercialModelsByIdGet**
> CommercialBuildingType SquarefootmodelCommercialModelsByIdGet (string id)

Gets a commercial model by Id.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class SquarefootmodelCommercialModelsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SquareFootModelCommercialModelsApi();
            var id = id_example;  // string | The model Id, for example 2017-001.

            try
            {
                // Gets a commercial model by Id.
                CommercialBuildingType result = apiInstance.SquarefootmodelCommercialModelsByIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SquareFootModelCommercialModelsApi.SquarefootmodelCommercialModelsByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| The model Id, for example 2017-001. | 

### Return type

[**CommercialBuildingType**](CommercialBuildingType.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="squarefootmodelcommercialmodelsget"></a>
# **SquarefootmodelCommercialModelsGet**
> NonpagedListCommercialBuildingType SquarefootmodelCommercialModelsGet (string releaseYear = null, string searchTerm = null)

Gets a list of commercial models.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class SquarefootmodelCommercialModelsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new SquareFootModelCommercialModelsApi();
            var releaseYear = releaseYear_example;  // string | The release year. Defaults to the most recent anual release. (optional) 
            var searchTerm = searchTerm_example;  // string | If supplied, returns only models containing the specified search terms in descriptions. (optional) 

            try
            {
                // Gets a list of commercial models.
                NonpagedListCommercialBuildingType result = apiInstance.SquarefootmodelCommercialModelsGet(releaseYear, searchTerm);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SquareFootModelCommercialModelsApi.SquarefootmodelCommercialModelsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **releaseYear** | **string**| The release year. Defaults to the most recent anual release. | [optional] 
 **searchTerm** | **string**| If supplied, returns only models containing the specified search terms in descriptions. | [optional] 

### Return type

[**NonpagedListCommercialBuildingType**](NonpagedListCommercialBuildingType.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

