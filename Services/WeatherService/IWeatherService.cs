using Refit;
using Services.External.WeatherApiWebService;

namespace Services.WeatherApiWebService.WeatherService;

public interface IWeatherService
{
    Task<ServiceResult<object>> GetWeatherDataAsync(ApiResponse<object> apiResponse,
        CancellationToken cancellationToken);
}