using Refit;
using Services.External.WeatherApiWebService.ForeCastAsync;

namespace Services.External.WeatherApiWebService;

public partial interface IWeatherApiWebService
{
    [Get("/v1/forecast.json?q={query}&days={days}&lang={language}")]
    Task<ApiResponse<WeatherApiResponse>> ForeCastAsync(string query, uint days, string language,
        CancellationToken cancellationToken = default);
}