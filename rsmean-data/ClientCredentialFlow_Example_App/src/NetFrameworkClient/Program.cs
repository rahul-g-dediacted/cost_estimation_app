using System;
using System.Linq;
using System.Text;
using System.Threading;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetFrameworkClient
{
    /// <summary>
    /// This sample shows how to use Client Credentials Flow to get an access token from Gordian's Identity Server 
    /// and request cost data from Gordian's API's.
    /// NuGet package IdentityModel is used.
    /// For more information about Identity Server please reference http://docs.identityserver.io/en/dev/index.html
    /// </summary>
    public class Program
    {
        //identity server endpoints:
        public const string BaseAddress = "https://login.gordian.com";
        public const string AuthorizeEndpoint = BaseAddress + "/connect/authorize";
        public const string LogoutEndpoint = BaseAddress + "/connect/endsession";
        public const string TokenEndpoint = BaseAddress + "/connect/token";
        public const string UserInfoEndpoint = BaseAddress + "/connect/userinfo";
        public const string IdentityTokenValidationEndpoint = BaseAddress + "/connect/identitytokenvalidation";
        public const string TokenRevocationEndpoint = BaseAddress + "/connect/revocation";

        //client credentials:
        public const string ClientId = "xxxx";
        public const string ClientSecret = "xxxx";

        //api endpoints:
        public const string DataApi = "https://dataapi-sb.gordian.com";
        public const string RequestScope = "rsm_api:costdata";

        private static TokenClient tokenClient { get; set; }
        private static TokenResponse tokenResponse { get; set; }

        static void Main(string[] args)
        {
            Timer tokenRefreshTimer = null;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };

            try
            {
                Console.WriteLine("*************************CLIENT CREDENTIAL FLOW***************************");

                //get API authorization token
                tokenClient = new TokenClient(TokenEndpoint, ClientId, ClientSecret);
                tokenResponse = tokenClient.RequestClientCredentialsAsync(RequestScope).Result;
                ShowResponse(tokenResponse);
                Console.WriteLine();

                //set the API Client's global configuration AccessToken to the token received from Identity Server
                Configuration.Default.AccessToken = tokenResponse.AccessToken;
                Configuration.Default.BasePath = DataApi;

                //Setup a Timer to asynchronously refresh the token before it expires. Tokens expire after ~ 1 hour
                var autoEvent = new AutoResetEvent(false);
                int refreshTime = (int)TimeSpan.FromSeconds(tokenResponse.ExpiresIn).Subtract(TimeSpan.FromMinutes(5)).TotalMilliseconds;
                tokenRefreshTimer = new Timer(RefreshToken, autoEvent, refreshTime, refreshTime);

                //Create a client for each set of Endpoints. Each set matches a group of endpoints from the RSMeans API Explorer (https://dataapi-sb.gordian.com/swagger/ui/)
                var locationClient = new CostDataLocationsApi();
                var releaseClient = new CostDataReleasesApi();
                var laborTypeClient = new CostDataLaborTypesApi();

                var unitCatalogsClient = new CostDataUnitCatalogsApi();
                var unitDivisionClient = new CostDataUnitDivisionsApi();
                var unitLinesClient = new CostDataUnitCostLinesApi();
                var equipmentRentalsClient = new CostDataUnitEquipmentRentalCostLinesApi();


                //Use the Locations Endpoint to retrieve the full list of locations
                //Providing no search term will return the entire location list.
                Console.WriteLine("Retrieve the list of locations using the Locations Endpoint");
                var locations = locationClient.CostdataLocationsGet();
                Console.WriteLine(JsonConvert.SerializeObject(locations.Items.GetRange(0, 5)));
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.WriteLine();

                Console.WriteLine(
                    "Search for locations using full City Name, search terms do not currently support searching by State or Country");
                locations = locationClient.CostdataLocationsGet(searchTerm: "Aberdeen");
                Console.WriteLine(JsonConvert.SerializeObject(locations));
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.WriteLine();

                //All location ids follow the pattern(remove any spaces from the city name): <countryCode>-<stateCode>-<city>
                //The default is the National Average: us-us-national
                var locationId = "us-ny-newyork";


                Console.WriteLine(
                    "Use the Releases endpoint to list all available releases and select the release Id matching the year and period (an, q1, q2, etc.)");
                var releases = releaseClient.CostdataReleasesGet();
                Console.WriteLine(JsonConvert.SerializeObject(releases));
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.WriteLine();

                //Release Id's all follow the pattern: <Year>-<Period>
                var release = releases.Items.First(r => r.Year.Equals("2019") && r.Period.Equals("an")).Id;


                Console.WriteLine(
                    "Use the Labor Types API to list the available labor types");
                var laborTypes = laborTypeClient.CostdataLaborTypesGet();
                Console.WriteLine(JsonConvert.SerializeObject(laborTypes));
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.WriteLine();

                //The default labor type is Standard ("std")
                var laborType = "std";

                //Measurement System may be 'imp'' for Imperial Units or 'met' for Metric units
                var measurementSystem = "imp";


                //Assembly and Unit data is retrieved by Catalog and drilling down through Divisions to get Cost Lines per division.
                //An example for getting Unit Catalog data is provided below, and similar methods are used to get Assembly Data

                //Note: Unit Cost Lines can contain a list of modifiers that you may need to be applied to a final Estimate.
                //Modifiers can be retrieved by Unit Cost Line or by Modifier ID using the Unit Modifier endpoints

                Console.WriteLine(
                    "Use the Unit Catalogs endpoints to get a list of available catalogs which can be filtered");
                //All parameters are optional and the default will be used for each if not provided
                var unitCatalogs = unitCatalogsClient.CostdataUnitCatalogsGet(release, locationId, laborType, measurementSystem);
                Console.WriteLine(JsonConvert.SerializeObject(unitCatalogs));
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.WriteLine();

                //Unit Catalog Codes all follow the pattern: <Catalog Name abbreviation>-mf-<measurementSystem>-<laborType>-<releaseId>-<locationId>
                var catalogId = unitCatalogs.Items.FirstOrDefault().Id;


                //Use the Unit Divisions Endpoints to get the Master Format division hierarchy for a catalog
                //This is intended to be done by getting the root level divisions, then drilling down into the division
                //hierarchy by getting a division's children

                Console.WriteLine("Retrieving Master Format Hierarchy");
                Console.WriteLine("Retrieving level 1 divisions");
                var rootDivisions = unitDivisionClient.CostdataUnitCatalogsByCatIdDivisionsGet(catalogId);
                var l1Div = rootDivisions.Items.FirstOrDefault();
                Console.WriteLine(JsonConvert.SerializeObject(rootDivisions.Items.FirstOrDefault()));

                //Get Child Divisions
                Console.WriteLine("Retrieving Child Divisions");
                var childDivisions = unitDivisionClient.CostdataUnitCatalogsByCatIdDivisionsByIdChildrenGet(catalogId, l1Div.Id);
                Console.WriteLine(JsonConvert.SerializeObject(childDivisions.Items.FirstOrDefault()));
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.WriteLine();


                Console.WriteLine(
                    "You can determine how many Cost Lines exist per root division using the Unit Cost Line's _search endpoint");
                var unitLinesSearchResponse = unitLinesClient.CostdataUnitCatalogsByCatIdCostLinesSearchGet(catalogId,
                    includeDivisionCount: true, includeCostLines: false);
                var divisionFilter = unitLinesSearchResponse.Aggregations.Items.FirstOrDefault(div => div.DocCount > 0).DivisionId;
                Console.WriteLine(JsonConvert.SerializeObject(unitLinesSearchResponse));
                Console.WriteLine();

                Console.WriteLine("Use the Unit Cost Lines Endpoints to get paged lists of Unit Lines Per Catalog");
                Console.WriteLine("It is recommended to retrieve Unit Cost Lines by filtering by Division");
                var unitLinesResponse = unitLinesClient.CostdataUnitCatalogsByCatIdCostLinesGet(catalogId, divisionCode: divisionFilter, limit: 1);
                Console.WriteLine(JsonConvert.SerializeObject(unitLinesResponse));
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.WriteLine();

                Console.WriteLine(
                    "To retrieve Equipment Rental Unit Lines use the Equipment Rental Cost Line Endpoints");
                var euipmentRentalLinesResponse = equipmentRentalsClient.CostdataUnitCatalogsByCatIdEquipmentRentalCostLinesGet(catalogId, limit: 1);
                Console.WriteLine(JsonConvert.SerializeObject(euipmentRentalLinesResponse));
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n-- Error:\n" + ex);
            }

            if (tokenRefreshTimer != null)
                tokenRefreshTimer.Dispose();

            Console.WriteLine("Press Any Key to Exit");
            Console.ReadKey();
        }

        private static void ShowResponse(TokenResponse response)
        {
            if (!response.IsError)
            {
                Console.WriteLine("-- Token response:\n" + response.Json);

                if (response.AccessToken.Contains("."))
                {
                    Console.WriteLine("\n\n-- Access Token (decoded):");

                    var parts = response.AccessToken.Split('.');
                    var header = parts[0];
                    var claims = parts[1];

                    Console.WriteLine(JObject.Parse(Encoding.UTF8.GetString(Base64Url.Decode(header))));
                    Console.WriteLine(JObject.Parse(Encoding.UTF8.GetString(Base64Url.Decode(claims))));
                }
            }
            else
            {
                Console.WriteLine("\n\n-- Error: \n" + response.Error);
            }
        }

        private static async void RefreshToken(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            tokenResponse = await tokenClient.RequestClientCredentialsAsync(RequestScope);
            Configuration.Default.AccessToken = tokenResponse.AccessToken;
        }
    }
}
