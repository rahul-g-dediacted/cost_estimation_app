# Gordian.DataApi.Api.CostDataUnitDivisionsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataUnitCatalogsByCatIdDivisionsByIdChildrenGet**](CostDataUnitDivisionsApi.md#costdataunitcatalogsbycatiddivisionsbyidchildrenget) | **GET** /v1/costdata/unit/catalogs/{catId}/divisions/{id}/children | Gets assembly child divisions.
[**CostdataUnitCatalogsByCatIdDivisionsByIdGet**](CostDataUnitDivisionsApi.md#costdataunitcatalogsbycatiddivisionsbyidget) | **GET** /v1/costdata/unit/catalogs/{catId}/divisions/{id} | Gets a division with its direct children.
[**CostdataUnitCatalogsByCatIdDivisionsGet**](CostDataUnitDivisionsApi.md#costdataunitcatalogsbycatiddivisionsget) | **GET** /v1/costdata/unit/catalogs/{catId}/divisions | Gets a list of top level divisions.


<a name="costdataunitcatalogsbycatiddivisionsbyidchildrenget"></a>
# **CostdataUnitCatalogsByCatIdDivisionsByIdChildrenGet**
> NonpagedListUnitDivision CostdataUnitCatalogsByCatIdDivisionsByIdChildrenGet (string catId, string id, List<string> expand = null)

Gets assembly child divisions.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdDivisionsByIdChildrenGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitDivisionsApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets assembly child divisions.
                NonpagedListUnitDivision result = apiInstance.CostdataUnitCatalogsByCatIdDivisionsByIdChildrenGet(catId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitDivisionsApi.CostdataUnitCatalogsByCatIdDivisionsByIdChildrenGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **id** | **string**| The identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**NonpagedListUnitDivision**](NonpagedListUnitDivision.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataunitcatalogsbycatiddivisionsbyidget"></a>
# **CostdataUnitCatalogsByCatIdDivisionsByIdGet**
> UnitDivision CostdataUnitCatalogsByCatIdDivisionsByIdGet (string catId, string id, List<string> expand = null)

Gets a division with its direct children.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdDivisionsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitDivisionsApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The division identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a division with its direct children.
                UnitDivision result = apiInstance.CostdataUnitCatalogsByCatIdDivisionsByIdGet(catId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitDivisionsApi.CostdataUnitCatalogsByCatIdDivisionsByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **id** | **string**| The division identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**UnitDivision**](UnitDivision.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataunitcatalogsbycatiddivisionsget"></a>
# **CostdataUnitCatalogsByCatIdDivisionsGet**
> NonpagedListUnitDivision CostdataUnitCatalogsByCatIdDivisionsGet (string catId, List<string> expand = null)

Gets a list of top level divisions.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdDivisionsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitDivisionsApi();
            var catId = catId_example;  // string | The catalog identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a list of top level divisions.
                NonpagedListUnitDivision result = apiInstance.CostdataUnitCatalogsByCatIdDivisionsGet(catId, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitDivisionsApi.CostdataUnitCatalogsByCatIdDivisionsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**NonpagedListUnitDivision**](NonpagedListUnitDivision.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

