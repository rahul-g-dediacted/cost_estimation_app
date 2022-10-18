# Gordian.DataApi.Api.CostDataAssemblyCatalogsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataAssemblyCatalogsByIdGet**](CostDataAssemblyCatalogsApi.md#costdataassemblycatalogsbyidget) | **GET** /v1/costdata/assembly/catalogs/{id} | Gets a single cost data catalog.
[**CostdataAssemblyCatalogsGet**](CostDataAssemblyCatalogsApi.md#costdataassemblycatalogsget) | **GET** /v1/costdata/assembly/catalogs | Gets a list of the available cost data catalogs


<a name="costdataassemblycatalogsbyidget"></a>
# **CostdataAssemblyCatalogsByIdGet**
> AssemblyCatalog CostdataAssemblyCatalogsByIdGet (string id, List<string> expand = null)

Gets a single cost data catalog.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataAssemblyCatalogsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataAssemblyCatalogsApi();
            var id = id_example;  // string | The cost data catalog identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a single cost data catalog.
                AssemblyCatalog result = apiInstance.CostdataAssemblyCatalogsByIdGet(id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataAssemblyCatalogsApi.CostdataAssemblyCatalogsByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| The cost data catalog identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**AssemblyCatalog**](AssemblyCatalog.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataassemblycatalogsget"></a>
# **CostdataAssemblyCatalogsGet**
> NonpagedListAssemblyCatalog CostdataAssemblyCatalogsGet (string releaseId = null, string locationId = null, string laborType = null, string measurementSystem = null, string searchTerm = null, List<string> expand = null)

Gets a list of the available cost data catalogs

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataAssemblyCatalogsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataAssemblyCatalogsApi();
            var releaseId = releaseId_example;  // string | The release identifier. Defaults to the most recent annual release. (optional) 
            var locationId = locationId_example;  // string | The location identifier for computing localized costs. Defaults to US National Average (us-us-national). (optional) 
            var laborType = laborType_example;  // string | Specifies standard union or open shop unit lines. Defaults to standard union (std). (optional) 
            var measurementSystem = measurementSystem_example;  // string | Specifies the measurement system. Defaults to Imperial units (imp). (optional) 
            var searchTerm = searchTerm_example;  // string | If supplied, returns only unit lines containing the specified search terms. (optional) 
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a list of the available cost data catalogs
                NonpagedListAssemblyCatalog result = apiInstance.CostdataAssemblyCatalogsGet(releaseId, locationId, laborType, measurementSystem, searchTerm, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataAssemblyCatalogsApi.CostdataAssemblyCatalogsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **releaseId** | **string**| The release identifier. Defaults to the most recent annual release. | [optional] 
 **locationId** | **string**| The location identifier for computing localized costs. Defaults to US National Average (us-us-national). | [optional] 
 **laborType** | **string**| Specifies standard union or open shop unit lines. Defaults to standard union (std). | [optional] 
 **measurementSystem** | **string**| Specifies the measurement system. Defaults to Imperial units (imp). | [optional] 
 **searchTerm** | **string**| If supplied, returns only unit lines containing the specified search terms. | [optional] 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**NonpagedListAssemblyCatalog**](NonpagedListAssemblyCatalog.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

