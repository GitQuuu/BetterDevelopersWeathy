using System.Text.Json.Serialization;

namespace Services.External.WeatherApiWebService.ForeCastAsync;

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
    [JsonPropertyName("tz_id")]
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
    [JsonPropertyName("wind_mph")]
    public double WindMph { get; set; }
    [JsonPropertyName("wind_kph")]
    public double WindKph { get; set; }
    [JsonPropertyName("wind_deg")]
    public int WindDegree { get; set; }
    [JsonPropertyName("wind_dir")]
    public string WindDir { get; set; }
    [JsonPropertyName("pressure_mb")]
    public double PressureMb { get; set; }
    [JsonPropertyName("pressure_in")]
    public double PressureIn { get; set; }
    [JsonPropertyName("precip_mm")]
    public double PrecipMm { get; set; }
    [JsonPropertyName("precip_in")]
    public double PrecipIn { get; set; }
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
    [JsonPropertyName("cloud")]
    public int Cloud { get; set; }
    [JsonPropertyName("feels_like_c")]
    public double FeelslikeC { get; set; }
    [JsonPropertyName("feels_like_f")]
    public double FeelslikeF { get; set; }
    [JsonPropertyName("wind_chill_c")]
    public double WindchillC { get; set; }
    [JsonPropertyName("wind_chill_f")]
    public double WindchillF { get; set; }
    [JsonPropertyName("heat_index_c")]
    public double HeatindexC { get; set; }
    [JsonPropertyName("heat_index_f")]
    public double HeatindexF { get; set; }
    [JsonPropertyName("dew_point_c")]
    public double DewpointC { get; set; }
    [JsonPropertyName("dew_point_f")]
    public double DewpointF { get; set; }
    [JsonPropertyName("vis_km")]
    public double VisKm { get; set; }
    [JsonPropertyName("vis_miles")]
    public double VisMiles { get; set; }
    [JsonPropertyName("uv")]
    public double Uv { get; set; }
    [JsonPropertyName("gust_mph")]
    public double GustMph { get; set; }
    [JsonPropertyName("gust_kph")]
    public double GustKph { get; set; }
}

public class Forecast
{
    [JsonPropertyName("forecastday")]
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
    [JsonPropertyName("maxtemp_c")]
    public double MaxTempC { get; set; }
    [JsonPropertyName("maxtemp_f")]
    public double MaxTempF { get; set; }
    [JsonPropertyName("mintemp_c")]
    public double MinTempC { get; set; }
    [JsonPropertyName("mintemp_f")]
    public double MinTempF { get; set; }
    [JsonPropertyName("avgtemp_c")]
    public double AvgTempC { get; set; }
    [JsonPropertyName("avgtemp_f")]
    public double AvgTempF { get; set; }
    [JsonPropertyName("maxwind_mph")]
    public double MaxWindMph { get; set; }
    [JsonPropertyName("maxwind_kph")]
    public double MaxWindKph { get; set; }
    [JsonPropertyName("totalprecip_mm")]
    public double TotalPrecipMm { get; set; }
    [JsonPropertyName("totalprecip_in")]
    public double TotalPrecipIn { get; set; }
    [JsonPropertyName("totalsnow_cm")]
    public double TotalSnowCm { get; set; }
    [JsonPropertyName("avgvis_km")]
    public double AvgVisKm { get; set; }
    [JsonPropertyName("avgvis_miles")]
    public double AvgVisMiles { get; set; }
    [JsonPropertyName("avghumidity")]
    public int AvgHumidity { get; set; }
    [JsonPropertyName("daily_will_it_rain")]
    public int DailyWillItRain { get; set; }
    [JsonPropertyName("daily_chance_of_rain")]
    public int DailyChanceOfRain { get; set; }
    [JsonPropertyName("daily_will_it_snow")]
    public int DailyWillItSnow { get; set; }
    [JsonPropertyName("daily_chance_of_snow")]
    public int DailyChanceOfSnow { get; set; }
    [JsonPropertyName("condition")]
    public WeatherCondition Condition { get; set; }
    [JsonPropertyName("uv")]
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
    [JsonPropertyName("time_epoch")]
    public long TimeEpoch { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("temp_c")]
    public double TempC { get; set; }

    [JsonPropertyName("temp_f")]
    public double TempF { get; set; }

    [JsonPropertyName("is_day")]
    public int IsDay { get; set; }

    [JsonPropertyName("condition")]
    public WeatherCondition Condition { get; set; }

    [JsonPropertyName("wind_mph")]
    public double WindMph { get; set; }

    [JsonPropertyName("wind_kph")]
    public double WindKph { get; set; }

    [JsonPropertyName("wind_degree")]
    public int WindDegree { get; set; }

    [JsonPropertyName("wind_dir")]
    public string WindDir { get; set; }

    [JsonPropertyName("pressure_mb")]
    public double PressureMb { get; set; }

    [JsonPropertyName("pressure_in")]
    public double PressureIn { get; set; }

    [JsonPropertyName("precip_mm")]
    public double PrecipMm { get; set; }

    [JsonPropertyName("precip_in")]
    public double PrecipIn { get; set; }

    [JsonPropertyName("snow_cm")]
    public double SnowCm { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    [JsonPropertyName("cloud")]
    public int Cloud { get; set; }

    [JsonPropertyName("feelslike_c")]
    public double FeelslikeC { get; set; }

    [JsonPropertyName("feelslike_f")]
    public double FeelslikeF { get; set; }

    [JsonPropertyName("windchill_c")]
    public double WindchillC { get; set; }

    [JsonPropertyName("windchill_f")]
    public double WindchillF { get; set; }

    [JsonPropertyName("heatindex_c")]
    public double HeatindexC { get; set; }

    [JsonPropertyName("heatindex_f")]
    public double HeatindexF { get; set; }

    [JsonPropertyName("dewpoint_c")]
    public double DewpointC { get; set; }

    [JsonPropertyName("dewpoint_f")]
    public double DewpointF { get; set; }

    [JsonPropertyName("will_it_rain")]
    public int WillItRain { get; set; }

    [JsonPropertyName("chance_of_rain")]
    public int ChanceOfRain { get; set; }

    [JsonPropertyName("will_it_snow")]
    public int WillItSnow { get; set; }

    [JsonPropertyName("chance_of_snow")]
    public int ChanceOfSnow { get; set; }

    [JsonPropertyName("vis_km")]
    public double VisKm { get; set; }

    [JsonPropertyName("vis_miles")]
    public double VisMiles { get; set; }

    [JsonPropertyName("gust_mph")]
    public double GustMph { get; set; }

    [JsonPropertyName("gust_kph")]
    public double GustKph { get; set; }

    [JsonPropertyName("uv")]
    public double Uv { get; set; }
}

public class WeatherCondition
{
    public string Text { get; set; }
    public string Icon { get; set; }
    public int Code { get; set; }
}
