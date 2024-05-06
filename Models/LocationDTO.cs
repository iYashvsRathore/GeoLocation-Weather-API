namespace WeatherAPI.Models
{
    public class LocationDTO
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public Location? Data { get; set; }
        public string? ErrorMessage { get; set; } = default;
    }


    public class Location
    {
        public Summary Summary { get; set; }
        public Result[] Results { get; set; }
    }

    public class Summary
    {
        public string Query { get; set; }
        public string QueryType { get; set; }
        public int QueryTime { get; set; }
        public int NumResults { get; set; }
        public int Offset { get; set; }
        public int TotalResults { get; set; }
        public int FuzzyLevel { get; set; }
    }

    public class Result
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public float Score { get; set; }
        public string EntityType { get; set; }
        public Matchconfidence MatchConfidence { get; set; }
        public Address Address { get; set; }
        public Position Position { get; set; }
        public Viewport Viewport { get; set; }
        public Boundingbox BoundingBox { get; set; }
        public Datasources DataSources { get; set; }
    }

    public class Matchconfidence
    {
        public float Score { get; set; }
    }

    public class Address
    {
        public string Municipality { get; set; }
        public string CountrySecondarySubdivision { get; set; }
        public string CountrySubdivision { get; set; }
        public string CountrySubdivisionName { get; set; }
        public string CountrySubdivisionCode { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string CountryCodeISO3 { get; set; }
        public string FreeformAddress { get; set; }
        public string MunicipalitySubdivision { get; set; }
        public string MunicipalitySecondarySubdivision { get; set; }
        public string StreetName { get; set; }
        public string LocalName { get; set; }
    }

    public class Position
    {
        public float Lat { get; set; }
        public float Lon { get; set; }
    }

    public class Viewport
    {
        public Topleftpoint TopLeftPoint { get; set; }
        public Btmrightpoint BtmRightPoint { get; set; }
    }

    public class Topleftpoint
    {
        public float Lat { get; set; }
        public float Lon { get; set; }
    }

    public class Btmrightpoint
    {
        public float Lat { get; set; }
        public float Lon { get; set; }
    }

    public class Boundingbox
    {
        public Topleftpoint1 TopLeftPoint { get; set; }
        public Btmrightpoint1 BtmRightPoint { get; set; }
    }

    public class Topleftpoint1
    {
        public float Lat { get; set; }
        public float Lon { get; set; }
    }

    public class Btmrightpoint1
    {
        public float Lat { get; set; }
        public float Lon { get; set; }
    }

    public class Datasources
    {
        public Geometry Geometry { get; set; }
    }

    public class Geometry
    {
        public string Id { get; set; }
    }

}
