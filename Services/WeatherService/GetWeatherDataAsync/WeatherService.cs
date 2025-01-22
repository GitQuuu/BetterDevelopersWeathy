using Services.External.WeatherApiWebService;

namespace Services.External.WeatherService;

public partial class WeatherService
{
    public Task<ServiceResult<object>> GetWeatherDataAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}