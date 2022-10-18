# Gordian.DataApi.Api.CostDataReleasesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataReleasesByIdGet**](CostDataReleasesApi.md#costdatareleasesbyidget) | **GET** /v1/costdata/releases/{id} | Gets a single release.
[**CostdataReleasesGet**](CostDataReleasesApi.md#costdatareleasesget) | **GET** /v1/costdata/releases | Gets a non-paged list of releases.


<a name="costdatareleasesbyidget"></a>
# **CostdataReleasesByIdGet**
> Release CostdataReleasesByIdGet (string id)

Gets a single release.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataReleasesByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataReleasesApi();
            var id = id_example;  // string | The release identifier.

            try
            {
                // Gets a single release.
                Release result = apiInstance.CostdataReleasesByIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataReleasesApi.CostdataReleasesByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| The release identifier. | 

### Return type

[**Release**](Release.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdatareleasesget"></a>
# **CostdataReleasesGet**
> NonpagedListRelease CostdataReleasesGet ()

Gets a non-paged list of releases.

Includes all details for each release returned.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataReleasesGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataReleasesApi();

            try
            {
                // Gets a non-paged list of releases.
                NonpagedListRelease result = apiInstance.CostdataReleasesGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataReleasesApi.CostdataReleasesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**NonpagedListRelease**](NonpagedListRelease.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

