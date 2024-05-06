using Newtonsoft.Json;
using System.Net;
using WeatherAPI.Clients;
using WeatherAPI.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherForecastHttpClient _httpClient;
        private readonly ILocationService _locationService;
        private readonly ILogger<WeatherService> _logger;
        public WeatherService(WeatherForecastHttpClient httpClient, ILocationService locationService, ILogger<WeatherService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException();
            _locationService = locationService ?? throw new ArgumentNullException(); ;
            _logger = logger ?? throw new ArgumentNullException();
        }

        public async Task<WeatherForecastDTO> GetWeatherForecast(RequestDTO requestDTO)
        {
            try
            {
                var locationResponse = await _locationService.GetLocationDetails(requestDTO.LocationName).ConfigureAwait(false);
                if (locationResponse.Success)
                {
                    // Handle Location successful response
                    var pos = _locationService.GetCoordinates(locationResponse);

                    requestDTO.Latitude = pos.Lat;
                    requestDTO.Longitude = pos.Lon;

                    var weatherResponse = await _httpClient.GetWeatherForecast(requestDTO).ConfigureAwait(false);

                    if (weatherResponse.IsSuccessStatusCode)
                    {
                        // Handle Weather successful response
                        var content = await weatherResponse.Content.ReadFromJsonAsync<WeatherForecast>();
                        _logger.LogInformation($"Weather Data: {JsonConvert.SerializeObject(content)}");
                        return new WeatherForecastDTO() { Success = true, StatusCode = Convert.ToInt32(weatherResponse.StatusCode), Data = content, ErrorMessage = string.Empty };
                    }
                    else
                    {
                        // Handle Weather error response
                        var errorMessage = await weatherResponse.Content.ReadAsStringAsync();
                        _logger.LogError($"Weather API Failure: {errorMessage}");
                        return new WeatherForecastDTO() { Success = false, StatusCode = Convert.ToInt32(weatherResponse.StatusCode), Data = null, ErrorMessage = errorMessage };
                    }

                }
                else
                {
                    _logger.LogError($"Azure MapLocation API Failure: {locationResponse.ErrorMessage}");
                    // Handle Location error response
                    return new WeatherForecastDTO() { Success = false, StatusCode = Convert.ToInt32(locationResponse.StatusCode), Data = null, ErrorMessage = $"Azure Maps API Failure: {locationResponse.ErrorMessage}" };
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Exception details: {ex.Message}");
                return new WeatherForecastDTO() { Success = false, StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError), Data = null, ErrorMessage = ex.Message };
            }
        }
    }
}
