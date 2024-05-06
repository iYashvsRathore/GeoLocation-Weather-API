using WeatherAPI.Models;

namespace WeatherAPI.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherForecastDTO> GetWeatherForecast(RequestDTO request);
    }
}
