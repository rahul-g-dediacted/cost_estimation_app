# Gordian.DataApi.Api.CostDataUnitModifiersApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersByIdGet**](CostDataUnitModifiersApi.md#costdataunitcatalogsbycatidcostlinesbylineidmodifiersbyidget) | **GET** /v1/costdata/unit/catalogs/{catId}/costlines/{lineId}/modifiers/{id} | Gets a single modifier for a unit cost line.
[**CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersGet**](CostDataUnitModifiersApi.md#costdataunitcatalogsbycatidcostlinesbylineidmodifiersget) | **GET** /v1/costdata/unit/catalogs/{catId}/costlines/{lineId}/modifiers | Gets a list of modifiers for a unit cost line.


<a name="costdataunitcatalogsbycatidcostlinesbylineidmodifiersbyidget"></a>
# **CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersByIdGet**
> ModifierApplied CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersByIdGet (string catId, string lineId, string id, List<string> expand = null)

Gets a single modifier for a unit cost line.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitModifiersApi();
            var catId = catId_example;  // string | The catalog identifier.
            var lineId = lineId_example;  // string | The unit line identifier.
            var id = id_example;  // string | The modifier identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a single modifier for a unit cost line.
                ModifierApplied result = apiInstance.CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersByIdGet(catId, lineId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitModifiersApi.CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **lineId** | **string**| The unit line identifier. | 
 **id** | **string**| The modifier identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**ModifierApplied**](ModifierApplied.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataunitcatalogsbycatidcostlinesbylineidmodifiersget"></a>
# **CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersGet**
> NonpagedListModifierApplied CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersGet (string catId, string lineId, List<string> expand = null)

Gets a list of modifiers for a unit cost line.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitModifiersApi();
            var catId = catId_example;  // string | The catalog identifier.
            var lineId = lineId_example;  // string | The unit line identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a list of modifiers for a unit cost line.
                NonpagedListModifierApplied result = apiInstance.CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersGet(catId, lineId, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitModifiersApi.CostdataUnitCatalogsByCatIdCostlinesByLineIdModifiersGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **lineId** | **string**| The unit line identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**NonpagedListModifierApplied**](NonpagedListModifierApplied.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

