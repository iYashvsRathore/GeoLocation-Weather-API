using WeatherAPI.Clients;
using WeatherAPI.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class AzureMapLocationService : ILocationService
    {
        private readonly LocationHttpClient _httpClient;
        private readonly ILogger<AzureMapLocationService> _logger;
        public AzureMapLocationService(LocationHttpClient httpClient, ILogger<AzureMapLocationService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException();
            _logger = logger ?? throw new ArgumentNullException();
        }
        public async Task<LocationDTO> GetLocationDetails(string locationQuery)
        {
            _logger.LogInformation($"Get Location details from the Azure Map Location service");
            var locationResponse = await _httpClient.GetLocation(locationQuery).ConfigureAwait(false);

            if (locationResponse.IsSuccessStatusCode)
            {
                // Handle successful response
                var content = await locationResponse.Content.ReadFromJsonAsync<Location>();
                return new LocationDTO() { Success = true, StatusCode = Convert.ToInt32(locationResponse.StatusCode), Data = content, ErrorMessage = string.Empty };
            }
            else
            {
                // Handle error response
                var errorMessage = await locationResponse.Content.ReadAsStringAsync();
                return new LocationDTO() { Success = false, StatusCode = Convert.ToInt32(locationResponse.StatusCode), Data = null, ErrorMessage = errorMessage };
            }
        }

        public Position GetCoordinates(LocationDTO locationDTO) 
        {
            _logger.LogInformation($"Getting Co-ordinates from the Location data");
            return locationDTO?.Data?.Results?.FirstOrDefault()?.Position ?? new Position() { Lat = 0.00f, Lon = 0.00f };
        }

    }
}
