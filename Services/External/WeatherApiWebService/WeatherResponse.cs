using System.Text.Json.Serialization;

namespace Services.External.WeatherApiWebService;

public class WeatherApiResponse
{
    public Location Location { get; set; }
    public CurrentWeather Current { get; set; }
    public Forecast Forecast { get; set; }
}

public class Location
{
    public string Name { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string TzId { get; set; }
    public long LocaltimeEpoch { get; set; }
    public string Localtime { get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("last_updated_epoch")]
    public long LastUpdatedEpoch { get; set; }
    [JsonPropertyName("last_updated")]
    public string LastUpdated { get; set; }
    [JsonPropertyName("temp_c")]
    public double TempC { get; set; }
    [JsonPropertyName("temp_f")]
    public double TempF { get; set; }
    [JsonPropertyName("is_day")]
    public int IsDay { get; set; }
    [JsonPropertyName("condition")]
    public WeatherCondition Condition { get; set; }
    public double WindMph { get; set; }
    public double WindKph { get; set; }
    public int WindDegree { get; set; }
    public string WindDir { get; set; }
    public double PressureMb { get; set; }
    public double PressureIn { get; set; }
    public double PrecipMm { get; set; }
    public double PrecipIn { get; set; }
    public int Humidity { get; set; }
    public int Cloud { get; set; }
    public double FeelslikeC { get; set; }
    public double FeelslikeF { get; set; }
    public double WindchillC { get; set; }
    public double WindchillF { get; set; }
    public double HeatindexC { get; set; }
    public double HeatindexF { get; set; }
    public double DewpointC { get; set; }
    public double DewpointF { get; set; }
    public double VisKm { get; set; }
    public double VisMiles { get; set; }
    public double Uv { get; set; }
    public double GustMph { get; set; }
    public double GustKph { get; set; }
}

public class Forecast
{
    public List<ForecastDay> ForecastDay { get; set; }
}

public class ForecastDay
{
    public string Date { get; set; }
    public long DateEpoch { get; set; }
    public DayWeather Day { get; set; }
    public Astro Astro { get; set; }
    public List<HourWeather> Hour { get; set; }
}

public class DayWeather
{
    public double MaxTempC { get; set; }
    public double MaxTempF { get; set; }
    public double MinTempC { get; set; }
    public double MinTempF { get; set; }
    public double AvgTempC { get; set; }
    public double AvgTempF { get; set; }
    public double MaxWindMph { get; set; }
    public double MaxWindKph { get; set; }
    public double TotalPrecipMm { get; set; }
    public double TotalPrecipIn { get; set; }
    public double TotalSnowCm { get; set; }
    public double AvgVisKm { get; set; }
    public double AvgVisMiles { get; set; }
    public int AvgHumidity { get; set; }
    public int DailyWillItRain { get; set; }
    public int DailyChanceOfRain { get; set; }
    public int DailyWillItSnow { get; set; }
    public int DailyChanceOfSnow { get; set; }
    public WeatherCondition Condition { get; set; }
    public double Uv { get; set; }
}

public class Astro
{
    public string Sunrise { get; set; }
    public string Sunset { get; set; }
    public string Moonrise { get; set; }
    public string Moonset { get; set; }
    public string MoonPhase { get; set; }
    public int MoonIllumination { get; set; }
    public int IsMoonUp { get; set; }
    public int IsSunUp { get; set; }
}

public class HourWeather
{
    public long TimeEpoch { get; set; }
    public string Time { get; set; }
    public double TempC { get; set; }
    public double TempF { get; set; }
    public int IsDay { get; set; }
    public WeatherCondition Condition { get; set; }
    public double WindMph { get; set; }
    public double WindKph { get; set; }
    public int WindDegree { get; set; }
    public string WindDir { get; set; }
    public double PressureMb { get; set; }
    public double PressureIn { get; set; }
    public double PrecipMm { get; set; }
    public double PrecipIn { get; set; }
    public double SnowCm { get; set; }
    public int Humidity { get; set; }
    public int Cloud { get; set; }
    public double FeelslikeC { get; set; }
    public double FeelslikeF { get; set; }
    public double WindchillC { get; set; }
    public double WindchillF { get; set; }
    public double HeatindexC { get; set; }
    public double HeatindexF { get; set; }
    public double DewpointC { get; set; }
    public double DewpointF { get; set; }
    public int WillItRain { get; set; }
    public int ChanceOfRain { get; set; }
    public int WillItSnow { get; set; }
    public int ChanceOfSnow { get; set; }
    public double VisKm { get; set; }
    public double VisMiles { get; set; }
    public double GustMph { get; set; }
    public double GustKph { get; set; }
    public double Uv { get; set; }
}

public class WeatherCondition
{
    public string Text { get; set; }
    public string Icon { get; set; }
    public int Code { get; set; }
}
