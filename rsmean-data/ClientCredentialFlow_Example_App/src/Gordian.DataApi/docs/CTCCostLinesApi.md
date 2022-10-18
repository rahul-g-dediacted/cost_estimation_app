# Gordian.DataApi.Api.CTCCostLinesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CtcCatalogsByCatIdCostLinesByIdGet**](CTCCostLinesApi.md#ctccatalogsbycatidcostlinesbyidget) | **GET** /v1/ctc/catalogs/{catId}/costlines/{id} | Gets a single CTC cost line.
[**CtcCatalogsByCatIdCostLinesGet**](CTCCostLinesApi.md#ctccatalogsbycatidcostlinesget) | **GET** /v1/ctc/catalogs/{catId}/costlines | Gets a list of CTC cost lines.
[**CtcCatalogsByCatIdCostLinesSearchGet**](CTCCostLinesApi.md#ctccatalogsbycatidcostlinessearchget) | **GET** /v1/ctc/catalogs/{catId}/costlines/_search | Gets a list of CTC cost lines with aggregations at the top division level.


<a name="ctccatalogsbycatidcostlinesbyidget"></a>
# **CtcCatalogsByCatIdCostLinesByIdGet**
> CostLineDto CtcCatalogsByCatIdCostLinesByIdGet (string catId, string id)

Gets a single CTC cost line.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CtcCatalogsByCatIdCostLinesByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CTCCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The unit line identifier.

            try
            {
                // Gets a single CTC cost line.
                CostLineDto result = apiInstance.CtcCatalogsByCatIdCostLinesByIdGet(catId, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CTCCostLinesApi.CtcCatalogsByCatIdCostLinesByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **id** | **string**| The unit line identifier. | 

### Return type

[**CostLineDto**](CostLineDto.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ctccatalogsbycatidcostlinesget"></a>
# **CtcCatalogsByCatIdCostLinesGet**
> PagedListCostLineDto CtcCatalogsByCatIdCostLinesGet (string catId, string searchTerm = null, string divisionId = null, int? offset = null, int? limit = null)

Gets a list of CTC cost lines.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CtcCatalogsByCatIdCostLinesGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CTCCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var searchTerm = searchTerm_example;  // string | If supplied, returns only unit lines containing the specified search terms. (optional) 
            var divisionId = divisionId_example;  // string | If supplied, searches within a specified division. (optional) 
            var offset = 56;  // int? | For paging, specify the offset from which to start returning results. Defaults to zero. (optional) 
            var limit = 56;  // int? | For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional) 

            try
            {
                // Gets a list of CTC cost lines.
                PagedListCostLineDto result = apiInstance.CtcCatalogsByCatIdCostLinesGet(catId, searchTerm, divisionId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CTCCostLinesApi.CtcCatalogsByCatIdCostLinesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **searchTerm** | **string**| If supplied, returns only unit lines containing the specified search terms. | [optional] 
 **divisionId** | **string**| If supplied, searches within a specified division. | [optional] 
 **offset** | **int?**| For paging, specify the offset from which to start returning results. Defaults to zero. | [optional] 
 **limit** | **int?**| For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. | [optional] 

### Return type

[**PagedListCostLineDto**](PagedListCostLineDto.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ctccatalogsbycatidcostlinessearchget"></a>
# **CtcCatalogsByCatIdCostLinesSearchGet**
> CostLineSearchResultDto CtcCatalogsByCatIdCostLinesSearchGet (string catId, bool? includeDivisionCount = null, bool? includeCostLines = null, bool? sortByLineNumber = null, string searchTerm = null, string divisionId = null, int? offset = null, int? limit = null)

Gets a list of CTC cost lines with aggregations at the top division level.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CtcCatalogsByCatIdCostLinesSearchGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CTCCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var includeDivisionCount = true;  // bool? | If true, the search result will include the number of unit lines that match the key word search for each division. Defaults to true. (optional) 
            var includeCostLines = true;  // bool? | If true, the search result will include unit lines that match the key word search. Defaults to true. (optional) 
            var sortByLineNumber = true;  // bool? | If true, the search result will sorted by CSI numbers. Defaults to true. (optional) 
            var searchTerm = searchTerm_example;  // string | If supplied, returns only unit lines containing the specified search terms. (optional) 
            var divisionId = divisionId_example;  // string | If supplied, searches within a specified division. (optional) 
            var offset = 56;  // int? | For paging, specify the offset from which to start returning results. Defaults to zero. (optional) 
            var limit = 56;  // int? | For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional) 

            try
            {
                // Gets a list of CTC cost lines with aggregations at the top division level.
                CostLineSearchResultDto result = apiInstance.CtcCatalogsByCatIdCostLinesSearchGet(catId, includeDivisionCount, includeCostLines, sortByLineNumber, searchTerm, divisionId, offset, limit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CTCCostLinesApi.CtcCatalogsByCatIdCostLinesSearchGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **includeDivisionCount** | **bool?**| If true, the search result will include the number of unit lines that match the key word search for each division. Defaults to true. | [optional] 
 **includeCostLines** | **bool?**| If true, the search result will include unit lines that match the key word search. Defaults to true. | [optional] 
 **sortByLineNumber** | **bool?**| If true, the search result will sorted by CSI numbers. Defaults to true. | [optional] 
 **searchTerm** | **string**| If supplied, returns only unit lines containing the specified search terms. | [optional] 
 **divisionId** | **string**| If supplied, searches within a specified division. | [optional] 
 **offset** | **int?**| For paging, specify the offset from which to start returning results. Defaults to zero. | [optional] 
 **limit** | **int?**| For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. | [optional] 

### Return type

[**CostLineSearchResultDto**](CostLineSearchResultDto.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

