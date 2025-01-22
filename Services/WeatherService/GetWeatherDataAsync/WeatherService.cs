using Refit;
using Services.External.WeatherApiWebService;

namespace Services.WeatherService;

public partial class WeatherService
{
    public Task<ServiceResult<object>> GetWeatherDataAsync(ApiResponse<object> apiResponse,CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}