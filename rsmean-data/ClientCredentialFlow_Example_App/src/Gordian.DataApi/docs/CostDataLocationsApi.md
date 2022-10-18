# Gordian.DataApi.Api.CostDataLocationsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataLocationsByIdGet**](CostDataLocationsApi.md#costdatalocationsbyidget) | **GET** /v1/costdata/locations/{id} | Gets a single location.
[**CostdataLocationsGet**](CostDataLocationsApi.md#costdatalocationsget) | **GET** /v1/costdata/locations | Gets a non-paged list of locations.


<a name="costdatalocationsbyidget"></a>
# **CostdataLocationsByIdGet**
> Location CostdataLocationsByIdGet (string id)

Gets a single location.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataLocationsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataLocationsApi();
            var id = id_example;  // string | The location identifier

            try
            {
                // Gets a single location.
                Location result = apiInstance.CostdataLocationsByIdGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataLocationsApi.CostdataLocationsByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| The location identifier | 

### Return type

[**Location**](Location.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdatalocationsget"></a>
# **CostdataLocationsGet**
> NonpagedListLocation CostdataLocationsGet (string searchTerm = null)

Gets a non-paged list of locations.

Includes all details for each location returned.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataLocationsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataLocationsApi();
            var searchTerm = searchTerm_example;  // string | If supplied, returns only locations containing the specified search term. (optional) 

            try
            {
                // Gets a non-paged list of locations.
                NonpagedListLocation result = apiInstance.CostdataLocationsGet(searchTerm);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataLocationsApi.CostdataLocationsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **searchTerm** | **string**| If supplied, returns only locations containing the specified search term. | [optional] 

### Return type

[**NonpagedListLocation**](NonpagedListLocation.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

