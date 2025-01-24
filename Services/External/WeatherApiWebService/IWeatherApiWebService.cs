using Refit;

namespace Services.External.WeatherApiWebService;

/// <summary>
/// 3rd party api for weather data, no concrete class is needed because of Refit
/// </summary>
public interface IWeatherApiWebService
{
    [Get("/v1/forecast.json?q={query}&days={days}&lang={language}")]
    Task<ApiResponse<WeatherApiResponse>> ForeCastAsync(string query, uint days, string language,
        CancellationToken cancellationToken = default);
}