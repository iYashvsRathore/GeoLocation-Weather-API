using WeatherAPI.Models;

namespace WeatherAPI.Interfaces
{
    public interface ILocationService
    {
        Task<LocationDTO> GetLocationDetails(string locationoQuery);
        Position GetCoordinates(LocationDTO locationDTO);
    }
}
