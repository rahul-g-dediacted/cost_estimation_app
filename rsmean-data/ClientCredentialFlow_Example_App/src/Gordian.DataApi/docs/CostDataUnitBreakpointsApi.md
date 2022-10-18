# Gordian.DataApi.Api.CostDataUnitBreakpointsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsByIdGet**](CostDataUnitBreakpointsApi.md#costdataunitcatalogsbycatidcostlinesbylineidbreakpointsbyidget) | **GET** /v1/costdata/unit/catalogs/{catId}/costlines/{lineId}/breakpoints/{id} | Gets a single breakpoint for a unit cost line
[**CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsGet**](CostDataUnitBreakpointsApi.md#costdataunitcatalogsbycatidcostlinesbylineidbreakpointsget) | **GET** /v1/costdata/unit/catalogs/{catId}/costlines/{lineId}/breakpoints | Gets a list of breakpoints for a unit cost line


<a name="costdataunitcatalogsbycatidcostlinesbylineidbreakpointsbyidget"></a>
# **CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsByIdGet**
> BreakpointApplied CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsByIdGet (string catId, string lineId, string id, List<string> expand = null)

Gets a single breakpoint for a unit cost line

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitBreakpointsApi();
            var catId = catId_example;  // string | 
            var lineId = lineId_example;  // string | 
            var id = id_example;  // string | The identifier
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a single breakpoint for a unit cost line
                BreakpointApplied result = apiInstance.CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsByIdGet(catId, lineId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitBreakpointsApi.CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**|  | 
 **lineId** | **string**|  | 
 **id** | **string**| The identifier | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**BreakpointApplied**](BreakpointApplied.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataunitcatalogsbycatidcostlinesbylineidbreakpointsget"></a>
# **CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsGet**
> NonpagedListBreakpointApplied CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsGet (string catId, string lineId, List<string> expand = null)

Gets a list of breakpoints for a unit cost line

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitBreakpointsApi();
            var catId = catId_example;  // string | 
            var lineId = lineId_example;  // string | 
            var expand = new List<string>(); // List<string> |  (optional) 

            try
            {
                // Gets a list of breakpoints for a unit cost line
                NonpagedListBreakpointApplied result = apiInstance.CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsGet(catId, lineId, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitBreakpointsApi.CostdataUnitCatalogsByCatIdCostlinesByLineIdBreakpointsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**|  | 
 **lineId** | **string**|  | 
 **expand** | [**List&lt;string&gt;**](string.md)|  | [optional] 

### Return type

[**NonpagedListBreakpointApplied**](NonpagedListBreakpointApplied.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

