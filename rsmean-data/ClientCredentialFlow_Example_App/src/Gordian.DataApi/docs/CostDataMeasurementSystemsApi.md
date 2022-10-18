# Gordian.DataApi.Api.CostDataMeasurementSystemsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataMeasurementSystemsGet**](CostDataMeasurementSystemsApi.md#costdatameasurementsystemsget) | **GET** /v1/costdata/measurementsystems | Gets a lookup collection of measurement system enum values and descriptions.


<a name="costdatameasurementsystemsget"></a>
# **CostdataMeasurementSystemsGet**
> List<EnumValueDescription> CostdataMeasurementSystemsGet ()

Gets a lookup collection of measurement system enum values and descriptions.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataMeasurementSystemsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataMeasurementSystemsApi();

            try
            {
                // Gets a lookup collection of measurement system enum values and descriptions.
                List&lt;EnumValueDescription&gt; result = apiInstance.CostdataMeasurementSystemsGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataMeasurementSystemsApi.CostdataMeasurementSystemsGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<EnumValueDescription>**](EnumValueDescription.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

