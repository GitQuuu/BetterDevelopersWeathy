using Refit;

namespace Services.External.WeatherApiWebService;

public interface IWeatherApiWebService
{
    [Get("/v1/forecast.json?q={query}&days={days}&lang={lang}")]
    Task<ServiceResult<dynamic>> GetWeatherDataAsync(string query, int days, string language);
}