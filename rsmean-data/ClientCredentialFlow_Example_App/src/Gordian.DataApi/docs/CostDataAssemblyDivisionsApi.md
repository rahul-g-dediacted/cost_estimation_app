# Gordian.DataApi.Api.CostDataAssemblyDivisionsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataAssemblyCatalogsByCatIdDivisionsByIdChildrenGet**](CostDataAssemblyDivisionsApi.md#costdataassemblycatalogsbycatiddivisionsbyidchildrenget) | **GET** /v1/costdata/assembly/catalogs/{catId}/divisions/{id}/children | Gets assembly child divisions.
[**CostdataAssemblyCatalogsByCatIdDivisionsByIdGet**](CostDataAssemblyDivisionsApi.md#costdataassemblycatalogsbycatiddivisionsbyidget) | **GET** /v1/costdata/assembly/catalogs/{catId}/divisions/{id} | Gets an assembly division.
[**CostdataAssemblyCatalogsByCatIdDivisionsGet**](CostDataAssemblyDivisionsApi.md#costdataassemblycatalogsbycatiddivisionsget) | **GET** /v1/costdata/assembly/catalogs/{catId}/divisions | Gets a list of top level assembly divisions.


<a name="costdataassemblycatalogsbycatiddivisionsbyidchildrenget"></a>
# **CostdataAssemblyCatalogsByCatIdDivisionsByIdChildrenGet**
> NonpagedListAssemblyDivision CostdataAssemblyCatalogsByCatIdDivisionsByIdChildrenGet (string catId, string id, List<string> expand = null)

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
    public class CostdataAssemblyCatalogsByCatIdDivisionsByIdChildrenGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataAssemblyDivisionsApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets assembly child divisions.
                NonpagedListAssemblyDivision result = apiInstance.CostdataAssemblyCatalogsByCatIdDivisionsByIdChildrenGet(catId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataAssemblyDivisionsApi.CostdataAssemblyCatalogsByCatIdDivisionsByIdChildrenGet: " + e.Message );
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

[**NonpagedListAssemblyDivision**](NonpagedListAssemblyDivision.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataassemblycatalogsbycatiddivisionsbyidget"></a>
# **CostdataAssemblyCatalogsByCatIdDivisionsByIdGet**
> AssemblyDivision CostdataAssemblyCatalogsByCatIdDivisionsByIdGet (string catId, string id, List<string> expand = null)

Gets an assembly division.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataAssemblyCatalogsByCatIdDivisionsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataAssemblyDivisionsApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The division identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets an assembly division.
                AssemblyDivision result = apiInstance.CostdataAssemblyCatalogsByCatIdDivisionsByIdGet(catId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataAssemblyDivisionsApi.CostdataAssemblyCatalogsByCatIdDivisionsByIdGet: " + e.Message );
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

[**AssemblyDivision**](AssemblyDivision.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataassemblycatalogsbycatiddivisionsget"></a>
# **CostdataAssemblyCatalogsByCatIdDivisionsGet**
> NonpagedListAssemblyDivision CostdataAssemblyCatalogsByCatIdDivisionsGet (string catId, List<string> expand = null)

Gets a list of top level assembly divisions.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataAssemblyCatalogsByCatIdDivisionsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataAssemblyDivisionsApi();
            var catId = catId_example;  // string | The catalog identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a list of top level assembly divisions.
                NonpagedListAssemblyDivision result = apiInstance.CostdataAssemblyCatalogsByCatIdDivisionsGet(catId, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataAssemblyDivisionsApi.CostdataAssemblyCatalogsByCatIdDivisionsGet: " + e.Message );
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

[**NonpagedListAssemblyDivision**](NonpagedListAssemblyDivision.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

