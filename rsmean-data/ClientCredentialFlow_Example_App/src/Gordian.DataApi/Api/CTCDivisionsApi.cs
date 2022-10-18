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
    public interface ICTCDivisionsApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Gets assembly child divisions.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>NonpagedListDivisionDto</returns>
        NonpagedListDivisionDto CtcCatalogsByCatIdDivisionsByIdChildrenGet (string catId, string id);

        /// <summary>
        /// Gets assembly child divisions.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>ApiResponse of NonpagedListDivisionDto</returns>
        ApiResponse<NonpagedListDivisionDto> CtcCatalogsByCatIdDivisionsByIdChildrenGetWithHttpInfo (string catId, string id);
        /// <summary>
        /// Gets a division with its direct children.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The division identifier.</param>
        /// <returns>DivisionDto</returns>
        DivisionDto CtcCatalogsByCatIdDivisionsByIdGet (string catId, string id);

        /// <summary>
        /// Gets a division with its direct children.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The division identifier.</param>
        /// <returns>ApiResponse of DivisionDto</returns>
        ApiResponse<DivisionDto> CtcCatalogsByCatIdDivisionsByIdGetWithHttpInfo (string catId, string id);
        /// <summary>
        /// Gets a list of top level divisions.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <returns>NonpagedListDivisionDto</returns>
        NonpagedListDivisionDto CtcCatalogsByCatIdDivisionsGet (string catId);

        /// <summary>
        /// Gets a list of top level divisions.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <returns>ApiResponse of NonpagedListDivisionDto</returns>
        ApiResponse<NonpagedListDivisionDto> CtcCatalogsByCatIdDivisionsGetWithHttpInfo (string catId);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Gets assembly child divisions.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Task of NonpagedListDivisionDto</returns>
        System.Threading.Tasks.Task<NonpagedListDivisionDto> CtcCatalogsByCatIdDivisionsByIdChildrenGetAsync (string catId, string id);

        /// <summary>
        /// Gets assembly child divisions.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Task of ApiResponse (NonpagedListDivisionDto)</returns>
        System.Threading.Tasks.Task<ApiResponse<NonpagedListDivisionDto>> CtcCatalogsByCatIdDivisionsByIdChildrenGetAsyncWithHttpInfo (string catId, string id);
        /// <summary>
        /// Gets a division with its direct children.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The division identifier.</param>
        /// <returns>Task of DivisionDto</returns>
        System.Threading.Tasks.Task<DivisionDto> CtcCatalogsByCatIdDivisionsByIdGetAsync (string catId, string id);

        /// <summary>
        /// Gets a division with its direct children.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The division identifier.</param>
        /// <returns>Task of ApiResponse (DivisionDto)</returns>
        System.Threading.Tasks.Task<ApiResponse<DivisionDto>> CtcCatalogsByCatIdDivisionsByIdGetAsyncWithHttpInfo (string catId, string id);
        /// <summary>
        /// Gets a list of top level divisions.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <returns>Task of NonpagedListDivisionDto</returns>
        System.Threading.Tasks.Task<NonpagedListDivisionDto> CtcCatalogsByCatIdDivisionsGetAsync (string catId);

        /// <summary>
        /// Gets a list of top level divisions.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <returns>Task of ApiResponse (NonpagedListDivisionDto)</returns>
        System.Threading.Tasks.Task<ApiResponse<NonpagedListDivisionDto>> CtcCatalogsByCatIdDivisionsGetAsyncWithHttpInfo (string catId);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class CTCDivisionsApi : ICTCDivisionsApi
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CTCDivisionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CTCDivisionsApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTCDivisionsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public CTCDivisionsApi(Configuration configuration = null)
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
        /// Gets assembly child divisions. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>NonpagedListDivisionDto</returns>
        public NonpagedListDivisionDto CtcCatalogsByCatIdDivisionsByIdChildrenGet (string catId, string id)
        {
             ApiResponse<NonpagedListDivisionDto> localVarResponse = CtcCatalogsByCatIdDivisionsByIdChildrenGetWithHttpInfo(catId, id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets assembly child divisions. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>ApiResponse of NonpagedListDivisionDto</returns>
        public ApiResponse< NonpagedListDivisionDto > CtcCatalogsByCatIdDivisionsByIdChildrenGetWithHttpInfo (string catId, string id)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsByIdChildrenGet");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsByIdChildrenGet");

            var localVarPath = "/v1/ctc/catalogs/{catId}/divisions/{id}/children";
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
                Exception exception = this.ExceptionFactory("CtcCatalogsByCatIdDivisionsByIdChildrenGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<NonpagedListDivisionDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NonpagedListDivisionDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(NonpagedListDivisionDto)));
        }

        /// <summary>
        /// Gets assembly child divisions. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Task of NonpagedListDivisionDto</returns>
        public async System.Threading.Tasks.Task<NonpagedListDivisionDto> CtcCatalogsByCatIdDivisionsByIdChildrenGetAsync (string catId, string id)
        {
             ApiResponse<NonpagedListDivisionDto> localVarResponse = await CtcCatalogsByCatIdDivisionsByIdChildrenGetAsyncWithHttpInfo(catId, id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets assembly child divisions. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Task of ApiResponse (NonpagedListDivisionDto)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<NonpagedListDivisionDto>> CtcCatalogsByCatIdDivisionsByIdChildrenGetAsyncWithHttpInfo (string catId, string id)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsByIdChildrenGet");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsByIdChildrenGet");

            var localVarPath = "/v1/ctc/catalogs/{catId}/divisions/{id}/children";
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
                Exception exception = this.ExceptionFactory("CtcCatalogsByCatIdDivisionsByIdChildrenGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<NonpagedListDivisionDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NonpagedListDivisionDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(NonpagedListDivisionDto)));
        }

        /// <summary>
        /// Gets a division with its direct children. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The division identifier.</param>
        /// <returns>DivisionDto</returns>
        public DivisionDto CtcCatalogsByCatIdDivisionsByIdGet (string catId, string id)
        {
             ApiResponse<DivisionDto> localVarResponse = CtcCatalogsByCatIdDivisionsByIdGetWithHttpInfo(catId, id);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets a division with its direct children. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The division identifier.</param>
        /// <returns>ApiResponse of DivisionDto</returns>
        public ApiResponse< DivisionDto > CtcCatalogsByCatIdDivisionsByIdGetWithHttpInfo (string catId, string id)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsByIdGet");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsByIdGet");

            var localVarPath = "/v1/ctc/catalogs/{catId}/divisions/{id}";
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
                Exception exception = this.ExceptionFactory("CtcCatalogsByCatIdDivisionsByIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<DivisionDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DivisionDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(DivisionDto)));
        }

        /// <summary>
        /// Gets a division with its direct children. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The division identifier.</param>
        /// <returns>Task of DivisionDto</returns>
        public async System.Threading.Tasks.Task<DivisionDto> CtcCatalogsByCatIdDivisionsByIdGetAsync (string catId, string id)
        {
             ApiResponse<DivisionDto> localVarResponse = await CtcCatalogsByCatIdDivisionsByIdGetAsyncWithHttpInfo(catId, id);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets a division with its direct children. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <param name="id">The division identifier.</param>
        /// <returns>Task of ApiResponse (DivisionDto)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<DivisionDto>> CtcCatalogsByCatIdDivisionsByIdGetAsyncWithHttpInfo (string catId, string id)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsByIdGet");
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsByIdGet");

            var localVarPath = "/v1/ctc/catalogs/{catId}/divisions/{id}";
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
                Exception exception = this.ExceptionFactory("CtcCatalogsByCatIdDivisionsByIdGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<DivisionDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (DivisionDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(DivisionDto)));
        }

        /// <summary>
        /// Gets a list of top level divisions. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <returns>NonpagedListDivisionDto</returns>
        public NonpagedListDivisionDto CtcCatalogsByCatIdDivisionsGet (string catId)
        {
             ApiResponse<NonpagedListDivisionDto> localVarResponse = CtcCatalogsByCatIdDivisionsGetWithHttpInfo(catId);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets a list of top level divisions. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <returns>ApiResponse of NonpagedListDivisionDto</returns>
        public ApiResponse< NonpagedListDivisionDto > CtcCatalogsByCatIdDivisionsGetWithHttpInfo (string catId)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsGet");

            var localVarPath = "/v1/ctc/catalogs/{catId}/divisions";
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
                Exception exception = this.ExceptionFactory("CtcCatalogsByCatIdDivisionsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<NonpagedListDivisionDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NonpagedListDivisionDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(NonpagedListDivisionDto)));
        }

        /// <summary>
        /// Gets a list of top level divisions. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <returns>Task of NonpagedListDivisionDto</returns>
        public async System.Threading.Tasks.Task<NonpagedListDivisionDto> CtcCatalogsByCatIdDivisionsGetAsync (string catId)
        {
             ApiResponse<NonpagedListDivisionDto> localVarResponse = await CtcCatalogsByCatIdDivisionsGetAsyncWithHttpInfo(catId);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets a list of top level divisions. 
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="catId">The catalog identifier.</param>
        /// <returns>Task of ApiResponse (NonpagedListDivisionDto)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<NonpagedListDivisionDto>> CtcCatalogsByCatIdDivisionsGetAsyncWithHttpInfo (string catId)
        {
            // verify the required parameter 'catId' is set
            if (catId == null)
                throw new ApiException(400, "Missing required parameter 'catId' when calling CTCDivisionsApi->CtcCatalogsByCatIdDivisionsGet");

            var localVarPath = "/v1/ctc/catalogs/{catId}/divisions";
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
                Exception exception = this.ExceptionFactory("CtcCatalogsByCatIdDivisionsGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<NonpagedListDivisionDto>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (NonpagedListDivisionDto) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(NonpagedListDivisionDto)));
        }

    }
}
