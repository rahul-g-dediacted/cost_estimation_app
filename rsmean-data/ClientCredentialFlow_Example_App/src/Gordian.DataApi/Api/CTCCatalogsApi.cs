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
    public interface ICTCCatalogsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Gets a single cost data catalog.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The cost data catalog identifier.</param>
        /// <returns>CatalogDto</returns>
        CatalogDto CtcCatalogsByIdGet (string id);

        /// <summary>
        /// Gets a single cost data catalog.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The cost data catalog identifier.</param>
        /// <returns>ApiResponse of CatalogDto</returns>
        ApiResponse<CatalogDto> CtcCatalogsByIdGetWithHttpInfo (string id);
        /// <summary>
        /// Gets a list of the available cost data catalogs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchTerm">If supplied, returns only catalogs containing the specified search terms. (optional)</param>
        /// <returns>NonpagedListCatalogDto</returns>
        NonpagedListCatalogDto CtcCatalogsGet (string searchTerm = null);

        /// <summary>
        /// Gets a list of the available cost data catalogs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchTerm">If supplied, returns only catalogs containing the specified search terms. (optional)</param>
        /// <returns>ApiResponse of NonpagedListCatalogDto</returns>
        ApiResponse<NonpagedListCatalogDto> CtcCatalogsGetWithHttpInfo (string searchTerm = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Gets a single cost data catalog.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The cost data catalog identifier.</param>
        /// <returns>Task of CatalogDto</returns>
        System.Threading.Tasks.Task<CatalogDto> CtcCatalogsByIdGetAsync (string id);

        /// <summary>
        /// Gets a single cost data catalog.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The cost data catalog identifier.</param>
        /// <returns>Task of ApiResponse (CatalogDto)</returns>
        System.Threading.Tasks.Task<ApiResponse<CatalogDto>> CtcCatalogsByIdGetAsyncWithHttpInfo (string id);
        /// <summary>
        /// Gets a list of the available cost data catalogs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchTerm">If supplied, returns only catalogs containing the specified search terms. (optional)</param>
        /// <returns>Task of NonpagedListCatalogDto</returns>
        System.Threading.Tasks.Task<NonpagedListCatalogDto> CtcCatalogsGetAsync (string searchTerm = null);

        /// <summary>
        /// Gets a list of the available cost data catalogs
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchTerm">If supplied, returns only catalogs containing the specified search terms. (optional)</param>
        /// <returns>Task of ApiResponse (NonpagedListCatalogDto)</returns>
        System.Threading.Tasks.Task<ApiResponse<NonpagedListCatalogDto>> CtcCatalogsGetAsyncWithHttpInfo (string searchTerm = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CTCCatalogsApi : ICTCCatalogsApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CTCCatalogsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CTCCatalogsApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTCCatalogsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CTCCatalogsApi(Configuration configuration = null)
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
        /// Gets a single cost data catalog. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The cost data catalog identifier.</param>
        /// <returns>CatalogDto</returns>
        public CatalogDto CtcCatalogsByIdGet (string id)
        {
             ApiResponse<CatalogDto> localVarResponse = CtcCatalogsByIdGetWithHttpInfo(id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets a single cost data catalog. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The cost data catalog identifier.</param>
        /// <returns>ApiResponse of CatalogDto</returns>
        public ApiResponse< CatalogDto > CtcCatalogsByIdGetWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CTCCatalogsApi->CtcCatalogsByIdGet");

            var localVarPath = "/v1/ctc/catalogs/{id}";
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
                Exception exception = this.ExceptionFactory("CtcCatalogsByIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CatalogDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CatalogDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(CatalogDto)));
        }

        /// <summary>
        /// Gets a single cost data catalog. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The cost data catalog identifier.</param>
        /// <returns>Task of CatalogDto</returns>
        public async System.Threading.Tasks.Task<CatalogDto> CtcCatalogsByIdGetAsync (string id)
        {
             ApiResponse<CatalogDto> localVarResponse = await CtcCatalogsByIdGetAsyncWithHttpInfo(id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets a single cost data catalog. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">The cost data catalog identifier.</param>
        /// <returns>Task of ApiResponse (CatalogDto)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<CatalogDto>> CtcCatalogsByIdGetAsyncWithHttpInfo (string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CTCCatalogsApi->CtcCatalogsByIdGet");

            var localVarPath = "/v1/ctc/catalogs/{id}";
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
                Exception exception = this.ExceptionFactory("CtcCatalogsByIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<CatalogDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (CatalogDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(CatalogDto)));
        }

        /// <summary>
        /// Gets a list of the available cost data catalogs 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchTerm">If supplied, returns only catalogs containing the specified search terms. (optional)</param>
        /// <returns>NonpagedListCatalogDto</returns>
        public NonpagedListCatalogDto CtcCatalogsGet (string searchTerm = null)
        {
             ApiResponse<NonpagedListCatalogDto> localVarResponse = CtcCatalogsGetWithHttpInfo(searchTerm);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets a list of the available cost data catalogs 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchTerm">If supplied, returns only catalogs containing the specified search terms. (optional)</param>
        /// <returns>ApiResponse of NonpagedListCatalogDto</returns>
        public ApiResponse< NonpagedListCatalogDto > CtcCatalogsGetWithHttpInfo (string searchTerm = null)
        {

            var localVarPath = "/v1/ctc/catalogs";
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

            if (searchTerm != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchTerm", searchTerm)); // query parameter

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
                Exception exception = this.ExceptionFactory("CtcCatalogsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<NonpagedListCatalogDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NonpagedListCatalogDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(NonpagedListCatalogDto)));
        }

        /// <summary>
        /// Gets a list of the available cost data catalogs 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchTerm">If supplied, returns only catalogs containing the specified search terms. (optional)</param>
        /// <returns>Task of NonpagedListCatalogDto</returns>
        public async System.Threading.Tasks.Task<NonpagedListCatalogDto> CtcCatalogsGetAsync (string searchTerm = null)
        {
             ApiResponse<NonpagedListCatalogDto> localVarResponse = await CtcCatalogsGetAsyncWithHttpInfo(searchTerm);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets a list of the available cost data catalogs 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="searchTerm">If supplied, returns only catalogs containing the specified search terms. (optional)</param>
        /// <returns>Task of ApiResponse (NonpagedListCatalogDto)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<NonpagedListCatalogDto>> CtcCatalogsGetAsyncWithHttpInfo (string searchTerm = null)
        {

            var localVarPath = "/v1/ctc/catalogs";
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

            if (searchTerm != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchTerm", searchTerm)); // query parameter

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
                Exception exception = this.ExceptionFactory("CtcCatalogsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<NonpagedListCatalogDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NonpagedListCatalogDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(NonpagedListCatalogDto)));
        }

    }
}
