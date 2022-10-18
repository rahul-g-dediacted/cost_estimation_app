# Gordian.DataApi.Api.CTCDivisionsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CtcCatalogsByCatIdDivisionsByIdChildrenGet**](CTCDivisionsApi.md#ctccatalogsbycatiddivisionsbyidchildrenget) | **GET** /v1/ctc/catalogs/{catId}/divisions/{id}/children | Gets assembly child divisions.
[**CtcCatalogsByCatIdDivisionsByIdGet**](CTCDivisionsApi.md#ctccatalogsbycatiddivisionsbyidget) | **GET** /v1/ctc/catalogs/{catId}/divisions/{id} | Gets a division with its direct children.
[**CtcCatalogsByCatIdDivisionsGet**](CTCDivisionsApi.md#ctccatalogsbycatiddivisionsget) | **GET** /v1/ctc/catalogs/{catId}/divisions | Gets a list of top level divisions.


<a name="ctccatalogsbycatiddivisionsbyidchildrenget"></a>
# **CtcCatalogsByCatIdDivisionsByIdChildrenGet**
> NonpagedListDivisionDto CtcCatalogsByCatIdDivisionsByIdChildrenGet (string catId, string id)

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
    public class CtcCatalogsByCatIdDivisionsByIdChildrenGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CTCDivisionsApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The identifier.

            try
            {
                // Gets assembly child divisions.
                NonpagedListDivisionDto result = apiInstance.CtcCatalogsByCatIdDivisionsByIdChildrenGet(catId, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CTCDivisionsApi.CtcCatalogsByCatIdDivisionsByIdChildrenGet: " + e.Message );
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

### Return type

[**NonpagedListDivisionDto**](NonpagedListDivisionDto.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ctccatalogsbycatiddivisionsbyidget"></a>
# **CtcCatalogsByCatIdDivisionsByIdGet**
> DivisionDto CtcCatalogsByCatIdDivisionsByIdGet (string catId, string id)

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
    public class CtcCatalogsByCatIdDivisionsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CTCDivisionsApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The division identifier.

            try
            {
                // Gets a division with its direct children.
                DivisionDto result = apiInstance.CtcCatalogsByCatIdDivisionsByIdGet(catId, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CTCDivisionsApi.CtcCatalogsByCatIdDivisionsByIdGet: " + e.Message );
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

### Return type

[**DivisionDto**](DivisionDto.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="ctccatalogsbycatiddivisionsget"></a>
# **CtcCatalogsByCatIdDivisionsGet**
> NonpagedListDivisionDto CtcCatalogsByCatIdDivisionsGet (string catId)

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
    public class CtcCatalogsByCatIdDivisionsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CTCDivisionsApi();
            var catId = catId_example;  // string | The catalog identifier.

            try
            {
                // Gets a list of top level divisions.
                NonpagedListDivisionDto result = apiInstance.CtcCatalogsByCatIdDivisionsGet(catId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CTCDivisionsApi.CtcCatalogsByCatIdDivisionsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 

### Return type

[**NonpagedListDivisionDto**](NonpagedListDivisionDto.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

