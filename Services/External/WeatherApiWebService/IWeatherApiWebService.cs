using Refit;

namespace Services.External.WeatherApiWebService;

public interface IWeatherApiWebService
{
    [Get("/v1/forecast.json?q={query}&days={days}&lang={language}")]
    Task<ApiResponse<dynamic>> GetWeatherDataAsync(string query, int days, string language);
}