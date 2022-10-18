# Gordian.DataApi.Api.CostDataUnitCostLinesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataUnitCatalogsByCatIdCostLinesByIdGet**](CostDataUnitCostLinesApi.md#costdataunitcatalogsbycatidcostlinesbyidget) | **GET** /v1/costdata/unit/catalogs/{catId}/costlines/{id} | Gets a single localized unit cost line.
[**CostdataUnitCatalogsByCatIdCostLinesGet**](CostDataUnitCostLinesApi.md#costdataunitcatalogsbycatidcostlinesget) | **GET** /v1/costdata/unit/catalogs/{catId}/costlines | Gets a list of localized unit cost lines
[**CostdataUnitCatalogsByCatIdCostLinesSearchGet**](CostDataUnitCostLinesApi.md#costdataunitcatalogsbycatidcostlinessearchget) | **GET** /v1/costdata/unit/catalogs/{catId}/costlines/_search | Gets a list of localized unit cost lines with aggregations at the top division level.


<a name="costdataunitcatalogsbycatidcostlinesbyidget"></a>
# **CostdataUnitCatalogsByCatIdCostLinesByIdGet**
> UnitCostLine CostdataUnitCatalogsByCatIdCostLinesByIdGet (string catId, string id, List<string> expand = null)

Gets a single localized unit cost line.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdCostLinesByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The unit line identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a single localized unit cost line.
                UnitCostLine result = apiInstance.CostdataUnitCatalogsByCatIdCostLinesByIdGet(catId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitCostLinesApi.CostdataUnitCatalogsByCatIdCostLinesByIdGet: " + e.Message );
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
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**UnitCostLine**](UnitCostLine.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataunitcatalogsbycatidcostlinesget"></a>
# **CostdataUnitCatalogsByCatIdCostLinesGet**
> PagedListUnitCostLine CostdataUnitCatalogsByCatIdCostLinesGet (string catId, string searchTerm = null, string divisionCode = null, List<string> expand = null, int? offset = null, int? limit = null)

Gets a list of localized unit cost lines

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdCostLinesGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var searchTerm = searchTerm_example;  // string | If supplied, returns only unit lines containing the specified search terms. (optional) 
            var divisionCode = divisionCode_example;  // string | If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional) 
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 
            var offset = 56;  // int? | For paging, specify the offset from which to start returning results. Defaults to zero. (optional) 
            var limit = 56;  // int? | For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional) 

            try
            {
                // Gets a list of localized unit cost lines
                PagedListUnitCostLine result = apiInstance.CostdataUnitCatalogsByCatIdCostLinesGet(catId, searchTerm, divisionCode, expand, offset, limit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitCostLinesApi.CostdataUnitCatalogsByCatIdCostLinesGet: " + e.Message );
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
 **divisionCode** | **string**| If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). | [optional] 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 
 **offset** | **int?**| For paging, specify the offset from which to start returning results. Defaults to zero. | [optional] 
 **limit** | **int?**| For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. | [optional] 

### Return type

[**PagedListUnitCostLine**](PagedListUnitCostLine.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataunitcatalogsbycatidcostlinessearchget"></a>
# **CostdataUnitCatalogsByCatIdCostLinesSearchGet**
> UnitLineSearchResult CostdataUnitCatalogsByCatIdCostLinesSearchGet (string catId, bool? includeDivisionCount = null, bool? includeCostLines = null, bool? sortByLineNumber = null, string costLineType = null, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null)

Gets a list of localized unit cost lines with aggregations at the top division level.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdCostLinesSearchGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var includeDivisionCount = true;  // bool? | If true, the search result will include the number of unit lines that match the key word search for each division. Defaults to true. (optional) 
            var includeCostLines = true;  // bool? | If true, the search result will include unit lines that match the key word search. Defaults to true. (optional) 
            var sortByLineNumber = true;  // bool? | If true, the search result will sorted by CSI numbers. Defaults to true. (optional) 
            var costLineType = costLineType_example;  // string | If supplied, returns only unit lines of the specified type. Default to all types. (optional) 
            var searchTerm = searchTerm_example;  // string | If supplied, returns only unit lines containing the specified search terms. (optional) 
            var divisionCode = divisionCode_example;  // string | If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional) 
            var offset = 56;  // int? | For paging, specify the offset from which to start returning results. Defaults to zero. (optional) 
            var limit = 56;  // int? | For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional) 

            try
            {
                // Gets a list of localized unit cost lines with aggregations at the top division level.
                UnitLineSearchResult result = apiInstance.CostdataUnitCatalogsByCatIdCostLinesSearchGet(catId, includeDivisionCount, includeCostLines, sortByLineNumber, costLineType, searchTerm, divisionCode, offset, limit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitCostLinesApi.CostdataUnitCatalogsByCatIdCostLinesSearchGet: " + e.Message );
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
 **costLineType** | **string**| If supplied, returns only unit lines of the specified type. Default to all types. | [optional] 
 **searchTerm** | **string**| If supplied, returns only unit lines containing the specified search terms. | [optional] 
 **divisionCode** | **string**| If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). | [optional] 
 **offset** | **int?**| For paging, specify the offset from which to start returning results. Defaults to zero. | [optional] 
 **limit** | **int?**| For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. | [optional] 

### Return type

[**UnitLineSearchResult**](UnitLineSearchResult.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

