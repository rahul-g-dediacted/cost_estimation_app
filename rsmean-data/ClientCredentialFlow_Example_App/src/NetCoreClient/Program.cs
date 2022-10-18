using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Gordian.DataApi.Api;
using Gordian.DataApi.Client;
using Gordian.DataApi.Model;
using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreClient.ConsoleApp.PostgreSQL;
using NetCoreClient.Models;

namespace NetCoreClient
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

        public static BloggingContext db;
        //client credentials:
        public const string ClientId = "rsm-api-prediction3d";
        public const string ClientSecret = "c5a46b5b-4c05-415f-90b4-450bc1557cc0";

        //api endpoints:
        public const string DataApi = "https://dataapi.gordian.com";
        public const string RequestScope = "rsm_api:costdata";

        private static TokenClient tokenClient { get; set; }
        private static TokenResponse tokenResponse { get; set; }

        static async Task Main(string[] args)
        {
            db = new BloggingContext();
            Timer tokenRefreshTimer = null;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };

            var mongoService = new MongoRSMeanService();


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

                var catalogClient = new CostDataAssemblyCatalogsApi();
                var assCostLineClient = new CostDataAssemblyCostLinesApi();

                var units = await unitCatalogsClient.CostdataUnitCatalogsGetAsync();


                var releases = await releaseClient.CostdataReleasesGetAsync();

                var locations = await locationClient.CostdataLocationsGetAsync();

                var locationEntities = await AddLocations(locations);
                var releaseEntities = await AddReleases(releases);
                var location1 = locationEntities.First(x => x.Id == "us-pr-sanjuan");
                var location2 = locationEntities.First(x => x.Id == "us-ms-laurel");
                var releaseQ2 = releaseEntities.First(x => x.Id == "2021-q2");
                var releaseQ3 = releaseEntities.First(x => x.Id == "2021-q3");

                //var labors=await laborTypeClient.CostdataLaborTypesGetAsync();

                var releaseId = "2021-q2";
                var locationId = "us-ms-laurel";

                {
                    var catalogs = await catalogClient.CostdataAssemblyCatalogsGetAsync(releaseQ3.Id, location2.Id, "std", "imp");

                    await AddAssemblyCatelog(catalogs);

                    var costLineList = new List<AssemblyCostLine>();

                    var list = catalogs.Items.ToList();

                    var i = 0;
                    foreach (var catalog in list)
                    {
                        i++;
                        Console.WriteLine("catalog" + catalog.CatalogName + "_" + i + "/" + list.Count);
                        var offset = 0;
                        while (true)
                        {
                            var costLinesPaged = await assCostLineClient.CostdataAssemblyCatalogsByCatIdCostLinesGetAsync(catalog.Id, limit: 100, offset: offset);
                            offset += 100;

                            costLineList.AddRange(costLinesPaged.Items);

                            if (costLinesPaged.PageNavigation.Next == null)
                            {
                                break;
                            }
                        }
                    }

                    await AddAssemblyCostLine(costLineList);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n-- Error:\n" + ex);
            }

            if (tokenRefreshTimer != null)
                await tokenRefreshTimer.DisposeAsync();

            Console.WriteLine("Press Any Key to Exit finishhhhhhhhhhhhhhhh");
            Console.ReadKey();

            return;
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


        public static async Task<List<LocationEntity>> AddLocations(NonpagedListLocation nonpaged)
        {
            var datas = await db.LocationEntity.ToListAsync();

            //db.LocationEntity.RemoveRange(datas);

            //datas = nonpaged.Items.Select(x => new LocationEntity()
            //{
            //    City = x.City,
            //    CountryCode = x.CountryCode,
            //    Id = x.Id,
            //    StateCode = x.StateCode,
            //    Href = x.Href
            //}).ToList();

            //await db.LocationEntity.AddRangeAsync(datas);
            //await db.SaveChangesAsync();

            return datas;
        }

        public static async Task<List<ReleaseEntity>> AddReleases(NonpagedListRelease nonpaged)
        {
            var datas = await db.ReleaseEntity.ToListAsync();

            //db.ReleaseEntity.RemoveRange(datas);

            //datas = nonpaged.Items.Select(x => new ReleaseEntity()
            //{
            //    Id = x.Id,
            //    Year = x.Year,
            //    Period = x.Period,
            //    Description = x.Description,
            //    Href = x.Href
            //}).ToList();

            //await db.ReleaseEntity.AddRangeAsync(datas);
            //await db.SaveChangesAsync();

            return datas;
        }

        public static async Task<List<AssemblyCatelogEntity>> AddAssemblyCatelog(NonpagedListAssemblyCatalog nonpaged)
        {
            //var datas = await db.AssemblyCatelogEntity.ToListAsync();

            //db.AssemblyCatelogEntity.RemoveRange(datas);
            var datas = nonpaged.Items.Select(x => new AssemblyCatelogEntity()
            {
                Id = x.Id,
                ReleaseId = x.Release.Id,
                LocationId = x.Location.Id,
                CatalogName = x.CatalogName,
                Href = x.Href
            }).ToList();

            await db.AssemblyCatelogEntity.AddRangeAsync(datas);
            await db.SaveChangesAsync();

            return datas;
        }


        public static async Task<List<AssemblyCostLineEntity>> AddAssemblyCostLine(List<AssemblyCostLine> list)
        {
            //var datas = await db.AssemblyCostLineEntity.ToListAsync();

            //db.AssemblyCostLineEntity.RemoveRange(datas);

            var datas = list.Select(x => new AssemblyCostLineEntity()
            {
                Idd = Guid.NewGuid(),
                RsId = x.Id,
                LineNumber = x.LineNumber,
                ReleaseId = x.Release.Id,
                AssemblyCatelogId = x.Catalog.Id,
                LocationId = x.Location.Id,
                Frequency = x.Frequency,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                UnitOfMeasure = x.UnitOfMeasure,
                BaseCosts = x.BaseCosts,
                CostFactors = x.CostFactors,
                LocalizedCosts = x.LocalizedCosts,
                AssemblyUnitCostLines = x.AssemblyUnitCostLines,
                Href = x.Href

            }).ToList();

            await db.AssemblyCostLineEntity.AddRangeAsync(datas);
            await db.SaveChangesAsync();

            return datas;
        }
    }
}
