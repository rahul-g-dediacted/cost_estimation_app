# Gordian.DataApi.Api.CTCCatalogsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CtcCatalogsByIdGet**](CTCCatalogsApi.md#ctccatalogsbyidget) | **GET** /v1/ctc/catalogs/{id} | Gets a single cost data catalog.
[**CtcCatalogsGet**](CTCCatalogsApi.md#ctccatalogsget) | **GET** /v1/ctc/catalogs | Gets a list of the available cost data catalogs


<a name="ctccatalogsbyidget"></a>
# **CtcCatalogsByIdGet**
> CatalogDto CtcCatalogsByIdGet (string id)

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
    public class CtcCatalogsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CTCCatalogsApi();
            var id = id_example;  // string | The cost data catalog identifier.

            try
            {
                // Gets a single cost data catalog.
                CatalogDto result = apiInstance.CtcCatalogsByIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CTCCatalogsApi.CtcCatalogsByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| The cost data catalog identifier. | 

### Return type

[**CatalogDto**](CatalogDto.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ctccatalogsget"></a>
# **CtcCatalogsGet**
> NonpagedListCatalogDto CtcCatalogsGet (string searchTerm = null)

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
    public class CtcCatalogsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CTCCatalogsApi();
            var searchTerm = searchTerm_example;  // string | If supplied, returns only catalogs containing the specified search terms. (optional) 

            try
            {
                // Gets a list of the available cost data catalogs
                NonpagedListCatalogDto result = apiInstance.CtcCatalogsGet(searchTerm);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CTCCatalogsApi.CtcCatalogsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **searchTerm** | **string**| If supplied, returns only catalogs containing the specified search terms. | [optional] 

### Return type

[**NonpagedListCatalogDto**](NonpagedListCatalogDto.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

