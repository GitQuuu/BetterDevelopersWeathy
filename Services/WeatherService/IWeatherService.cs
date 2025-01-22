namespace Services.External.WeatherApiWebService.WeatherService;

public interface IWeatherService
{
    Task<ServiceResult<object>> GetWeatherDataAsync(CancellationToken cancellationToken);
}