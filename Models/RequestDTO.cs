using System.Text.Json.Serialization;

namespace WeatherAPI.Models
{
    public class RequestDTO
    {
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; } = "auto";
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? TempratureUnit { get; set; } = "celsius";
        public string? TimeFormat { get; set; } = "iso8601";
        [JsonPropertyName("precipitation_unit")]
        public string? PrecipitationUnit { get; set; } = "mm";
    }
}
