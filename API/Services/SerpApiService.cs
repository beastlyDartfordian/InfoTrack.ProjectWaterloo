using System.Collections;
using System.Text.Json;
using API.Models;
using SerpApi;

namespace API.Services
{
    public class SerpApiService : ISerpApiService
    {
        private readonly ILogger<SerpApiService> logger;
        private readonly SerpApiSettings defaultSettings;

        private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        public SerpApiService(ILogger<SerpApiService> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.defaultSettings = configuration.GetSection("SerpApiSettings").Get<SerpApiSettings>();
        }

        public SerpApiResult GetResults(string searchTerm, SerpApiSettings? settings = null)
        {
            var ht = BuildHashtable(settings ?? this.defaultSettings);
            ht.Add("q", searchTerm);

            try
            {
                GoogleSearch search = new(ht, this.defaultSettings.ApiKey);
                string data = search.getRawResult("/search.json", search.GetParameter(true), true);

                return JsonSerializer.Deserialize<SerpApiResult>(data, this.serializerOptions);
            }
            catch (SerpApiSearchException ex)
            {
                this.logger.LogError(ex, "Exception getting results for Serp API");

                return new SerpApiResult
                {
                    SearchMetadata = new SearchMetadata
                    {
                        ErrorMessage = ex.Message
                    }
                };
            }
        }

        private Hashtable BuildHashtable(SerpApiSettings serpApiSettings)
        {
            Hashtable ht = new Hashtable();
            ht.Add("engine", serpApiSettings.Engine);
            ht.Add("location", serpApiSettings.Location);
            ht.Add("google_domain", serpApiSettings.Domain);
            ht.Add("gl", serpApiSettings.Country);
            ht.Add("hl", serpApiSettings.Language);
            ht.Add("num", serpApiSettings.ResultCount);

            return ht;
        }
    }
}
