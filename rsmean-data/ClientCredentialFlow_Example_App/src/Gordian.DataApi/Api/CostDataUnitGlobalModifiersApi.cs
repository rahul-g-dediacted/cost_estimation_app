/* 
 * RSMeans Consumer REST API V1
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;
using RestSharp;

namespace Gordian.DataApi.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICostDataUnitGlobalModifiersApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Gets a single Global Modifiers.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The global modifier identifier.</param>
        /// <returns>NonpagedListModifier</returns>
        NonpagedListModifier CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet (string catId, string id);

        /// <summary>
        /// Gets a single Global Modifiers.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The global modifier identifier.</param>
        /// <returns>ApiResponse of NonpagedListModifier</returns>
        ApiResponse<NonpagedListModifier> CostdataUnitCatalogsByCatIdGlobalModifiersByIdGetWithHttpInfo (string catId, string id);
        /// <summary>
        /// Gets a list of Global Modifiers for a catalog.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="searchTerm">If supplied, returns only unit lines containing the specified search terms. (optional)</param>
        /// <param name="divisionCode">If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional)</param>
        /// <param name="offset">For paging, specify the offset from which to start returning results. Defaults to zero. (optional)</param>
        /// <param name="limit">For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional)</param>
        /// <returns>PagedListGlobalModifier</returns>
        PagedListGlobalModifier CostdataUnitCatalogsByCatIdGlobalModifiersGet (string catId, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null);

        /// <summary>
        /// Gets a list of Global Modifiers for a catalog.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="searchTerm">If supplied, returns only unit lines containing the specified search terms. (optional)</param>
        /// <param name="divisionCode">If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional)</param>
        /// <param name="offset">For paging, specify the offset from which to start returning results. Defaults to zero. (optional)</param>
        /// <param name="limit">For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional)</param>
        /// <returns>ApiResponse of PagedListGlobalModifier</returns>
        ApiResponse<PagedListGlobalModifier> CostdataUnitCatalogsByCatIdGlobalModifiersGetWithHttpInfo (string catId, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Gets a single Global Modifiers.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The global modifier identifier.</param>
        /// <returns>Task of NonpagedListModifier</returns>
        System.Threading.Tasks.Task<NonpagedListModifier> CostdataUnitCatalogsByCatIdGlobalModifiersByIdGetAsync (string catId, string id);

        /// <summary>
        /// Gets a single Global Modifiers.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The global modifier identifier.</param>
        /// <returns>Task of ApiResponse (NonpagedListModifier)</returns>
        System.Threading.Tasks.Task<ApiResponse<NonpagedListModifier>> CostdataUnitCatalogsByCatIdGlobalModifiersByIdGetAsyncWithHttpInfo (string catId, string id);
        /// <summary>
        /// Gets a list of Global Modifiers for a catalog.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="searchTerm">If supplied, returns only unit lines containing the specified search terms. (optional)</param>
        /// <param name="divisionCode">If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional)</param>
        /// <param name="offset">For paging, specify the offset from which to start returning results. Defaults to zero. (optional)</param>
        /// <param name="limit">For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional)</param>
        /// <returns>Task of PagedListGlobalModifier</returns>
        System.Threading.Tasks.Task<PagedListGlobalModifier> CostdataUnitCatalogsByCatIdGlobalModifiersGetAsync (string catId, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null);

        /// <summary>
        /// Gets a list of Global Modifiers for a catalog.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="searchTerm">If supplied, returns only unit lines containing the specified search terms. (optional)</param>
        /// <param name="divisionCode">If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional)</param>
        /// <param name="offset">For paging, specify the offset from which to start returning results. Defaults to zero. (optional)</param>
        /// <param name="limit">For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional)</param>
        /// <returns>Task of ApiResponse (PagedListGlobalModifier)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedListGlobalModifier>> CostdataUnitCatalogsByCatIdGlobalModifiersGetAsyncWithHttpInfo (string catId, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CostDataUnitGlobalModifiersApi : ICostDataUnitGlobalModifiersApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CostDataUnitGlobalModifiersApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CostDataUnitGlobalModifiersApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CostDataUnitGlobalModifiersApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CostDataUnitGlobalModifiersApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Gets a single Global Modifiers. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The global modifier identifier.</param>
        /// <returns>NonpagedListModifier</returns>
        public NonpagedListModifier CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet (string catId, string id)
        {
             ApiResponse<NonpagedListModifier> localVarResponse = CostdataUnitCatalogsByCatIdGlobalModifiersByIdGetWithHttpInfo(catId, id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets a single Global Modifiers. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The global modifier identifier.</param>
        /// <returns>ApiResponse of NonpagedListModifier</returns>
        public ApiResponse< NonpagedListModifier > CostdataUnitCatalogsByCatIdGlobalModifiersByIdGetWithHttpInfo (string catId, string id)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CostDataUnitGlobalModifiersApi->CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CostDataUnitGlobalModifiersApi->CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet");

            var localVarPath = "/v1/costdata/unit/catalogs/{catId}/globalmodifiers/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (catId != null) localVarPathParams.Add("catId", this.Configuration.ApiClient.ParameterToString(catId)); // path parameter
            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter

            // authentication (rsmids_auth) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<NonpagedListModifier>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NonpagedListModifier) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(NonpagedListModifier)));
        }

        /// <summary>
        /// Gets a single Global Modifiers. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The global modifier identifier.</param>
        /// <returns>Task of NonpagedListModifier</returns>
        public async System.Threading.Tasks.Task<NonpagedListModifier> CostdataUnitCatalogsByCatIdGlobalModifiersByIdGetAsync (string catId, string id)
        {
             ApiResponse<NonpagedListModifier> localVarResponse = await CostdataUnitCatalogsByCatIdGlobalModifiersByIdGetAsyncWithHttpInfo(catId, id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets a single Global Modifiers. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The global modifier identifier.</param>
        /// <returns>Task of ApiResponse (NonpagedListModifier)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<NonpagedListModifier>> CostdataUnitCatalogsByCatIdGlobalModifiersByIdGetAsyncWithHttpInfo (string catId, string id)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CostDataUnitGlobalModifiersApi->CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CostDataUnitGlobalModifiersApi->CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet");

            var localVarPath = "/v1/costdata/unit/catalogs/{catId}/globalmodifiers/{id}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (catId != null) localVarPathParams.Add("catId", this.Configuration.ApiClient.ParameterToString(catId)); // path parameter
            if (id != null) localVarPathParams.Add("id", this.Configuration.ApiClient.ParameterToString(id)); // path parameter

            // authentication (rsmids_auth) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("CostdataUnitCatalogsByCatIdGlobalModifiersByIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<NonpagedListModifier>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NonpagedListModifier) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(NonpagedListModifier)));
        }

        /// <summary>
        /// Gets a list of Global Modifiers for a catalog. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="searchTerm">If supplied, returns only unit lines containing the specified search terms. (optional)</param>
        /// <param name="divisionCode">If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional)</param>
        /// <param name="offset">For paging, specify the offset from which to start returning results. Defaults to zero. (optional)</param>
        /// <param name="limit">For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional)</param>
        /// <returns>PagedListGlobalModifier</returns>
        public PagedListGlobalModifier CostdataUnitCatalogsByCatIdGlobalModifiersGet (string catId, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null)
        {
             ApiResponse<PagedListGlobalModifier> localVarResponse = CostdataUnitCatalogsByCatIdGlobalModifiersGetWithHttpInfo(catId, searchTerm, divisionCode, offset, limit);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets a list of Global Modifiers for a catalog. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="searchTerm">If supplied, returns only unit lines containing the specified search terms. (optional)</param>
        /// <param name="divisionCode">If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional)</param>
        /// <param name="offset">For paging, specify the offset from which to start returning results. Defaults to zero. (optional)</param>
        /// <param name="limit">For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional)</param>
        /// <returns>ApiResponse of PagedListGlobalModifier</returns>
        public ApiResponse< PagedListGlobalModifier > CostdataUnitCatalogsByCatIdGlobalModifiersGetWithHttpInfo (string catId, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CostDataUnitGlobalModifiersApi->CostdataUnitCatalogsByCatIdGlobalModifiersGet");

            var localVarPath = "/v1/costdata/unit/catalogs/{catId}/globalmodifiers";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (catId != null) localVarPathParams.Add("catId", this.Configuration.ApiClient.ParameterToString(catId)); // path parameter
            if (searchTerm != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchTerm", searchTerm)); // query parameter
            if (divisionCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "divisionCode", divisionCode)); // query parameter
            if (offset != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "offset", offset)); // query parameter
            if (limit != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "limit", limit)); // query parameter

            // authentication (rsmids_auth) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("CostdataUnitCatalogsByCatIdGlobalModifiersGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PagedListGlobalModifier>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PagedListGlobalModifier) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(PagedListGlobalModifier)));
        }

        /// <summary>
        /// Gets a list of Global Modifiers for a catalog. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="searchTerm">If supplied, returns only unit lines containing the specified search terms. (optional)</param>
        /// <param name="divisionCode">If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional)</param>
        /// <param name="offset">For paging, specify the offset from which to start returning results. Defaults to zero. (optional)</param>
        /// <param name="limit">For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional)</param>
        /// <returns>Task of PagedListGlobalModifier</returns>
        public async System.Threading.Tasks.Task<PagedListGlobalModifier> CostdataUnitCatalogsByCatIdGlobalModifiersGetAsync (string catId, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null)
        {
             ApiResponse<PagedListGlobalModifier> localVarResponse = await CostdataUnitCatalogsByCatIdGlobalModifiersGetAsyncWithHttpInfo(catId, searchTerm, divisionCode, offset, limit);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets a list of Global Modifiers for a catalog. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="searchTerm">If supplied, returns only unit lines containing the specified search terms. (optional)</param>
        /// <param name="divisionCode">If supplied, searches within a specified division. Accepts division codes for any level in the hierarchy (two, four, six or eight digit division codes). (optional)</param>
        /// <param name="offset">For paging, specify the offset from which to start returning results. Defaults to zero. (optional)</param>
        /// <param name="limit">For paging, specify the maximum number of unit lines to return in a single request. Defaults to 25 and Max value is 100. (optional)</param>
        /// <returns>Task of ApiResponse (PagedListGlobalModifier)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<PagedListGlobalModifier>> CostdataUnitCatalogsByCatIdGlobalModifiersGetAsyncWithHttpInfo (string catId, string searchTerm = null, string divisionCode = null, int? offset = null, int? limit = null)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CostDataUnitGlobalModifiersApi->CostdataUnitCatalogsByCatIdGlobalModifiersGet");

            var localVarPath = "/v1/costdata/unit/catalogs/{catId}/globalmodifiers";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (catId != null) localVarPathParams.Add("catId", this.Configuration.ApiClient.ParameterToString(catId)); // path parameter
            if (searchTerm != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchTerm", searchTerm)); // query parameter
            if (divisionCode != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "divisionCode", divisionCode)); // query parameter
            if (offset != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "offset", offset)); // query parameter
            if (limit != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "limit", limit)); // query parameter

            // authentication (rsmids_auth) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = this.ExceptionFactory("CostdataUnitCatalogsByCatIdGlobalModifiersGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<PagedListGlobalModifier>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (PagedListGlobalModifier) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(PagedListGlobalModifier)));
        }

    }
}
