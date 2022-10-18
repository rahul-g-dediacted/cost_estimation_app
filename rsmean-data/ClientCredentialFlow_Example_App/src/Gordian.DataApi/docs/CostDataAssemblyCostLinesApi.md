# Gordian.DataApi.Api.CostDataAssemblyCostLinesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataAssemblyCatalogsByCatIdCostLinesByIdGet**](CostDataAssemblyCostLinesApi.md#costdataassemblycatalogsbycatidcostlinesbyidget) | **GET** /v1/costdata/assembly/catalogs/{catId}/costlines/{id} | Gets a single localized assembly cost line.
[**CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsByIdGet**](CostDataAssemblyCostLinesApi.md#costdataassemblycatalogsbycatidcostlinesbylineidcomponentsbyidget) | **GET** /v1/costdata/assembly/catalogs/{catId}/costlines/{lineId}/components/{id} | Gets a single assembly unit cost line detail.
[**CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsGet**](CostDataAssemblyCostLinesApi.md#costdataassemblycatalogsbycatidcostlinesbylineidcomponentsget) | **GET** /v1/costdata/assembly/catalogs/{catId}/costlines/{lineId}/components | Gets list of assembly unit cost lines detail.
[**CostdataAssemblyCatalogsByCatIdCostLinesGet**](CostDataAssemblyCostLinesApi.md#costdataassemblycatalogsbycatidcostlinesget) | **GET** /v1/costdata/assembly/catalogs/{catId}/costlines | Gets a list of localized assembly cost lines


<a name="costdataassemblycatalogsbycatidcostlinesbyidget"></a>
# **CostdataAssemblyCatalogsByCatIdCostLinesByIdGet**
> AssemblyCostLine CostdataAssemblyCatalogsByCatIdCostLinesByIdGet (string catId, string id, List<string> expand = null)

Gets a single localized assembly cost line.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataAssemblyCatalogsByCatIdCostLinesByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataAssemblyCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The assembly line identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a single localized assembly cost line.
                AssemblyCostLine result = apiInstance.CostdataAssemblyCatalogsByCatIdCostLinesByIdGet(catId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataAssemblyCostLinesApi.CostdataAssemblyCatalogsByCatIdCostLinesByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **id** | **string**| The assembly line identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**AssemblyCostLine**](AssemblyCostLine.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataassemblycatalogsbycatidcostlinesbylineidcomponentsbyidget"></a>
# **CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsByIdGet**
> AssemblyUnitLineComponent CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsByIdGet (string catId, string lineId, string id, List<string> expand = null)

Gets a single assembly unit cost line detail.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataAssemblyCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var lineId = lineId_example;  // string | The assembly line identifier.
            var id = id_example;  // string | The unit line identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a single assembly unit cost line detail.
                AssemblyUnitLineComponent result = apiInstance.CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsByIdGet(catId, lineId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataAssemblyCostLinesApi.CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **lineId** | **string**| The assembly line identifier. | 
 **id** | **string**| The unit line identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**AssemblyUnitLineComponent**](AssemblyUnitLineComponent.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataassemblycatalogsbycatidcostlinesbylineidcomponentsget"></a>
# **CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsGet**
> NonpagedListAssemblyUnitLineComponent CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsGet (string catId, string lineId, List<string> expand = null)

Gets list of assembly unit cost lines detail.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataAssemblyCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var lineId = lineId_example;  // string | The assembly line identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets list of assembly unit cost lines detail.
                NonpagedListAssemblyUnitLineComponent result = apiInstance.CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsGet(catId, lineId, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataAssemblyCostLinesApi.CostdataAssemblyCatalogsByCatIdCostLinesByLineIdComponentsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **lineId** | **string**| The assembly line identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**NonpagedListAssemblyUnitLineComponent**](NonpagedListAssemblyUnitLineComponent.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataassemblycatalogsbycatidcostlinesget"></a>
# **CostdataAssemblyCatalogsByCatIdCostLinesGet**
> PagedListAssemblyCostLine CostdataAssemblyCatalogsByCatIdCostLinesGet (string catId, string searchTerm = null, string divisionCode = null, List<string> expand = null, int? offset = null, int? limit = null)

Gets a list of localized assembly cost lines

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataAssemblyCatalogsByCatIdCostLinesGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataAssemblyCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var searchTerm = searchTerm_example;  // string | If supplied, returns only assembly lines containing the specified search terms. (optional) 
            var divisionCode = divisionCode_example;  // string | If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy. (optional) 
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 
            var offset = 56;  // int? | For paging, specify the offset from which to start returning results. Defaults to zero. (optional) 
            var limit = 56;  // int? | For paging, specify the maximum number of Assembly lines to return in a single request. Defaults to 25 and Max value is 100. (optional) 

            try
            {
                // Gets a list of localized assembly cost lines
                PagedListAssemblyCostLine result = apiInstance.CostdataAssemblyCatalogsByCatIdCostLinesGet(catId, searchTerm, divisionCode, expand, offset, limit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataAssemblyCostLinesApi.CostdataAssemblyCatalogsByCatIdCostLinesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **searchTerm** | **string**| If supplied, returns only assembly lines containing the specified search terms. | [optional] 
 **divisionCode** | **string**| If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy. | [optional] 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 
 **offset** | **int?**| For paging, specify the offset from which to start returning results. Defaults to zero. | [optional] 
 **limit** | **int?**| For paging, specify the maximum number of Assembly lines to return in a single request. Defaults to 25 and Max value is 100. | [optional] 

### Return type

[**PagedListAssemblyCostLine**](PagedListAssemblyCostLine.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

