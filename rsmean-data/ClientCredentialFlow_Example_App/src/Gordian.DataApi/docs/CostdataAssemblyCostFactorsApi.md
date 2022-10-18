# Gordian.DataApi.Api.CostdataAssemblyCostFactorsApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataAssemblyCostFactorsByIdGet**](CostdataAssemblyCostFactorsApi.md#costdataassemblycostfactorsbyidget) | **GET** /v1/costdata/assembly/costfactors/{id} | Gets a single location.
[**CostdataAssemblyCostFactorsGet**](CostdataAssemblyCostFactorsApi.md#costdataassemblycostfactorsget) | **GET** /v1/costdata/assembly/costfactors | Gets a list of assembly line cost factors for a specific location and release.


<a name="costdataassemblycostfactorsbyidget"></a>
# **CostdataAssemblyCostFactorsByIdGet**
> LocalCostFactorData CostdataAssemblyCostFactorsByIdGet (string id, List<string> expand = null)

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
    public class CostdataAssemblyCostFactorsByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostdataAssemblyCostFactorsApi();
            var id = id_example;  // string | The location identifier
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a single location.
                LocalCostFactorData result = apiInstance.CostdataAssemblyCostFactorsByIdGet(id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostdataAssemblyCostFactorsApi.CostdataAssemblyCostFactorsByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| The location identifier | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**LocalCostFactorData**](LocalCostFactorData.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataassemblycostfactorsget"></a>
# **CostdataAssemblyCostFactorsGet**
> NonpagedListLocalCostFactorData CostdataAssemblyCostFactorsGet (string releaseId = null, string locationId = null, List<string> expand = null)

Gets a list of assembly line cost factors for a specific location and release.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataAssemblyCostFactorsGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostdataAssemblyCostFactorsApi();
            var releaseId = releaseId_example;  // string | The release identifier. Defaults to the most recent annual release. (optional) 
            var locationId = locationId_example;  // string | The location identifier for computing localized costs. Defaults to US National Average (us-us-national). (optional) 
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a list of assembly line cost factors for a specific location and release.
                NonpagedListLocalCostFactorData result = apiInstance.CostdataAssemblyCostFactorsGet(releaseId, locationId, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostdataAssemblyCostFactorsApi.CostdataAssemblyCostFactorsGet: " + e.Message );
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
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**NonpagedListLocalCostFactorData**](NonpagedListLocalCostFactorData.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

