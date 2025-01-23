using System.Net;
using System.Text.Json;
using Refit;
using Services.External.WeatherApiWebService;

namespace Services.WeatherService;

public partial class WeatherService
{
    public async Task<ServiceResult<WeatherApiResponse>> HandleWeatherDataAsync(ApiResponse<object> apiResponse,CancellationToken cancellationToken)
    {
        var weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(
            apiResponse.Content?.ToString(),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
       
        return new ServiceResult<WeatherApiResponse>(true, HttpStatusCode.OK,weatherData);
    }
}