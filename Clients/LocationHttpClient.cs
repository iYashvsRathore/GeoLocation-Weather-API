using Microsoft.Extensions.Options;
using WeatherAPI.Settings;

namespace WeatherAPI.Clients
{
    public class LocationHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly LocationSettings _options;
        private readonly ILogger<WeatherForecastHttpClient> _logger;
        public LocationHttpClient(HttpClient httpClient, IOptions<LocationSettings> options, ILogger<WeatherForecastHttpClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException();
            _options = options.Value ?? throw new ArgumentNullException();
            _logger = logger ?? throw new ArgumentNullException();
        }

        public async Task<HttpResponseMessage> GetLocation(string locationQuery)
        {
            var queryParam = $"?subscription-key={_options.SubscriptionKey}&api-version={_options.ApiVersion}&language={_options.Language}&query={locationQuery}";
            
            var response = await _httpClient.GetAsync(queryParam);

            return response;
        }
    }
}
