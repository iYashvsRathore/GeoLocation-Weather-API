using Microsoft.Extensions.Options;
using WeatherAPI.Models;
using WeatherAPI.Settings;

namespace WeatherAPI.Clients
{
    public class WeatherForecastHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly OpenmeteoSettings _options;
        private readonly ILogger<WeatherForecastHttpClient> _logger;
        public WeatherForecastHttpClient(HttpClient httpClient, IOptions<OpenmeteoSettings> options, ILogger<WeatherForecastHttpClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException();
            _options = options.Value ?? throw new ArgumentNullException();
            _logger = logger ?? throw new ArgumentNullException();
        }

        public async Task<HttpResponseMessage> GetWeatherForecast(RequestDTO request)
        {
            var queryParam = $"?latitude={request.Latitude}&longitude={request.Longitude}&timezone={request.Timezone}&start_date={request.StartDate}&end_date={request.EndDate}&temperature_unit={request.TempratureUnit}&timeformat={request.TimeFormat}&precipitation_unit={request.PrecipitationUnit}&current={_options.CurrentWeather}&daily={_options.DailyWeather}&hourly={_options.HourlyWeather}";
            
            var response = await _httpClient.GetAsync(queryParam);

            return response;
        }
    }
}
