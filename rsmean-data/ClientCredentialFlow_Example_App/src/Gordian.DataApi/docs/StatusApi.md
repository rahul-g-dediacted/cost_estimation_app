# Gordian.DataApi.Api.StatusApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ByVersionStatusGet**](StatusApi.md#byversionstatusget) | **GET** /v1/status | Gets the current status and Context information
[**Get**](StatusApi.md#get) | **GET** / | Gets the current status and Context information


<a name="byversionstatusget"></a>
# **ByVersionStatusGet**
> void ByVersionStatusGet ()

Gets the current status and Context information

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class ByVersionStatusGetExample
    {
        public void main()
        {
            var apiInstance = new StatusApi();

            try
            {
                // Gets the current status and Context information
                apiInstance.ByVersionStatusGet();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatusApi.ByVersionStatusGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="get"></a>
# **Get**
> void Get ()

Gets the current status and Context information

In production, this returns status 200 with no content.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class GetExample
    {
        public void main()
        {
            var apiInstance = new StatusApi();

            try
            {
                // Gets the current status and Context information
                apiInstance.Get();
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StatusApi.Get: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

