using Services.External.WeatherApiWebService;
using Services.External.WeatherApiWebService.ForeCastAsync;

namespace Services.WeatherService;

public partial interface IWeatherService
{
    Task<ServiceResult<WeatherApiResponse>> HandleWeatherDataAsync(WeatherApiResponse? apiResponse,
        CancellationToken cancellationToken);
}