using Refit;
using Services.External.WeatherApiWebService;
using Services.External.WeatherApiWebService.ForeCastAsync;

namespace Services.WeatherApiWebService.WeatherService;

public interface IWeatherService
{
    Task<ServiceResult<WeatherApiResponse>> HandleWeatherDataAsync(WeatherApiResponse? apiResponse,
        CancellationToken cancellationToken);
}