using Refit;
using Services.External.WeatherApiWebService.ForeCastAsync;

namespace Services.WeatherService;

public partial interface IWeatherService
{
    Task<ServiceResult<WeatherApiResponse>> HandleWeatherDataAsync(ApiResponse<WeatherApiResponse> apiResponse,
        CancellationToken cancellationToken);
}