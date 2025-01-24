namespace Services.External.WeatherApiWebService;

/// <summary>
/// Used for options pattern
/// </summary>
public class WeatherApiConfigurations
{
    public string Key { get; set; }
    public string? Endpoint { get; set; }
}