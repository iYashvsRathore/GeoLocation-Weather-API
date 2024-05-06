namespace WeatherAPI.Models
{
    public class WeatherForecastDTO
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public WeatherForecast? Data { get; set; }
        public string? ErrorMessage { get; set; } = default;

    }
    public class WeatherForecast
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string Timezone { get; set; }
        public string Timezone_abbreviation { get; set; }
        public float elevation { get; set; }
        public CurrentUnits Current_units { get; set; }
        public Current Current { get; set; }
        public HourlyUnits Hourly_units { get; set; }
        public Hourly Hourly { get; set; }
        public DailyUnits Daily_units { get; set; }
        public Daily Daily { get; set; }
    }

    public class CurrentUnits
    {
        public string time { get; set; }
        public string interval { get; set; }
        public string temperature_2m { get; set; }
        public string relative_humidity_2m { get; set; }
        public string apparent_temperature { get; set; }
        public string precipitation { get; set; }
    }

    public class Current
    {
        public string time { get; set; }
        public int interval { get; set; }
        public float temperature_2m { get; set; }
        public int relative_humidity_2m { get; set; }
        public float apparent_temperature { get; set; }
        public float precipitation { get; set; }
    }

    public class HourlyUnits
    {
        public string time { get; set; }
        public string temperature_2m { get; set; }
        public string relative_humidity_2m { get; set; }
        public string apparent_temperature { get; set; }
        public string precipitation { get; set; }
        public string precipitation_probability { get; set; }
    }

    public class Hourly
    {
        public string[] time { get; set; }
        public float[] temperature_2m { get; set; }
        public int[] relative_humidity_2m { get; set; }
        public float[] apparent_temperature { get; set; }
        public float[] precipitation { get; set; }
        public int[] precipitation_probability { get; set; }
    }

    public class DailyUnits
    {
        public string time { get; set; }
        public string temperature_2m_max { get; set; }
        public string temperature_2m_min { get; set; }
        public string apparent_temperature_max { get; set; }
        public string apparent_temperature_min { get; set; }
        public string precipitation_probability_max { get; set; }
    }

    public class Daily
    {
        public string[] Time { get; set; }
        public float[] Temperature_2m_max { get; set; }
        public float[] Temperature_2m_min { get; set; }
        public float[] Apparent_temperature_max { get; set; }
        public float[] Apparent_temperature_min { get; set; }
        public int[] Precipitation_probability_max { get; set; }
    }

}
