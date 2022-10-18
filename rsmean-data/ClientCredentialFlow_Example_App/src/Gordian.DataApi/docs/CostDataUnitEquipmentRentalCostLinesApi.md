# Gordian.DataApi.Api.CostDataUnitEquipmentRentalCostLinesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesByIdGet**](CostDataUnitEquipmentRentalCostLinesApi.md#costdataunitcatalogsbycatidequipmentrentalcostlinesbyidget) | **GET** /v1/costdata/unit/catalogs/{catId}/equipmentrentalcostlines/{id} | Gets a single localized equipment rental cost line..
[**CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesGet**](CostDataUnitEquipmentRentalCostLinesApi.md#costdataunitcatalogsbycatidequipmentrentalcostlinesget) | **GET** /v1/costdata/unit/catalogs/{catId}/equipmentrentalcostlines | Gets a list of localized equipment rental cost lines.


<a name="costdataunitcatalogsbycatidequipmentrentalcostlinesbyidget"></a>
# **CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesByIdGet**
> EquipmentRentalCostLine CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesByIdGet (string catId, string id, List<string> expand = null)

Gets a single localized equipment rental cost line..

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesByIdGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitEquipmentRentalCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var id = id_example;  // string | The unit line identifier.
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 

            try
            {
                // Gets a single localized equipment rental cost line..
                EquipmentRentalCostLine result = apiInstance.CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesByIdGet(catId, id, expand);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitEquipmentRentalCostLinesApi.CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **id** | **string**| The unit line identifier. | 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 

### Return type

[**EquipmentRentalCostLine**](EquipmentRentalCostLine.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="costdataunitcatalogsbycatidequipmentrentalcostlinesget"></a>
# **CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesGet**
> PagedListEquipmentRentalCostLine CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesGet (string catId, string searchTerm = null, string divisionCode = null, List<string> expand = null, int? offset = null, int? limit = null)

Gets a list of localized equipment rental cost lines.

### Example
```csharp
using System;
using System.Diagnostics;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;

namespace Example
{
    public class CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesGetExample
    {
        public void main()
        {
            // Configure OAuth2 access token for authorization: rsmids_auth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new CostDataUnitEquipmentRentalCostLinesApi();
            var catId = catId_example;  // string | The catalog identifier.
            var searchTerm = searchTerm_example;  // string | If supplied, returns only unit lines containing the specified search terms. (optional) 
            var divisionCode = divisionCode_example;  // string | If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional) 
            var expand = new List<string>(); // List<string> | A list of properties to expand. Applies only to expandable properties. (optional) 
            var offset = 56;  // int? | For paging, specify the offset from which to start returning results. Defaults to zero. (optional) 
            var limit = 56;  // int? | For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional) 

            try
            {
                // Gets a list of localized equipment rental cost lines.
                PagedListEquipmentRentalCostLine result = apiInstance.CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesGet(catId, searchTerm, divisionCode, expand, offset, limit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CostDataUnitEquipmentRentalCostLinesApi.CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **catId** | **string**| The catalog identifier. | 
 **searchTerm** | **string**| If supplied, returns only unit lines containing the specified search terms. | [optional] 
 **divisionCode** | **string**| If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). | [optional] 
 **expand** | [**List&lt;string&gt;**](string.md)| A list of properties to expand. Applies only to expandable properties. | [optional] 
 **offset** | **int?**| For paging, specify the offset from which to start returning results. Defaults to zero. | [optional] 
 **limit** | **int?**| For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. | [optional] 

### Return type

[**PagedListEquipmentRentalCostLine**](PagedListEquipmentRentalCostLine.md)

### Authorization

[rsmids_auth](../README.md#rsmids_auth)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

