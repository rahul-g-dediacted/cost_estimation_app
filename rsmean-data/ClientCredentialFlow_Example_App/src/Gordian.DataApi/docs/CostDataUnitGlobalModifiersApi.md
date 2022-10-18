# Gordian.DataApi.Api.CostDataUnitGlobalModifiersApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet**](CostDataUnitGlobalModifiersApi.md#costdataunitcatalogsbycatidglobalmodifiersbyidget) | **GET** /v1/costdata/unit/catalogs/{catId}/globalmodifiers/{id} | Gets a single Global Modifiers.
[**CostdataUnitCatalogsByCatIdGlobalModifiersGet**](CostDataUnitGlobalModifiersApi.md#costdataunitcatalogsbycatidglobalmodifiersget) | **GET** /v1/costdata/unit/catalogs/{catId}/globalmodifiers | Gets a list of Global Modifiers for a catalog.


<a name="costdataunitcatalogsbycatidglobalmodifiersbyidget"></a>
# **CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet**
> NonpagedListModifier CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet (string catId, string id)

Gets a single Global Modifiers.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdGlobalModifiersByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitGlobalModifiersApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The global modifier identifier.

            try
            {
                // Gets a single Global Modifiers.
                NonpagedListModifier result = apiInstance.CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet(catId, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitGlobalModifiersApi.CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **id** | **string**| The global modifier identifier. | 

### Return type

[**NonpagedListModifier**](NonpagedListModifier.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataunitcatalogsbycatidglobalmodifiersget"></a>
# **CostdataUnitCatalogsByCatIdGlobalModifiersGet**
> PagedListGlobalModifier CostdataUnitCatalogsByCatIdGlobalModifiersGet (string catId, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null)

Gets a list of Global Modifiers for a catalog.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdGlobalModifiersGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitGlobalModifiersApi();
            var catId = catId_example;  // string | The catalog identifier.
            var searchTerm = searchTerm_example;  // string | If supplied, returns only unit lines containing the specified search terms. (optional) 
            var divisionCode = divisionCode_example;  // string | If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional) 
            var offset = 56;  // int? | For paging, specify the offset from which to start returning results. Defaults to zero. (optional) 
            var limit = 56;  // int? | For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional) 

            try
            {
                // Gets a list of Global Modifiers for a catalog.
                PagedListGlobalModifier result = apiInstance.CostdataUnitCatalogsByCatIdGlobalModifiersGet(catId, searchTerm, divisionCode, offset, limit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitGlobalModifiersApi.CostdataUnitCatalogsByCatIdGlobalModifiersGet: " + e.Message );
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
 **offset** | **int?**| For paging, specify the offset from which to start returning results. Defaults to zero. | [optional] 
 **limit** | **int?**| For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. | [optional] 

### Return type

[**PagedListGlobalModifier**](PagedListGlobalModifier.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

