using System.Net;
using System.Text.Json;
using Refit;
using Services.External.WeatherApiWebService;

namespace Services.WeatherService;

public partial class WeatherService
{
    public async Task<ServiceResult<WeatherApiResponse>> HandleWeatherDataAsync(ApiResponse<object> apiResponse,CancellationToken cancellationToken)
    {
        if (apiResponse.Content is null)
        {
            return new ServiceResult<WeatherApiResponse>(false, HttpStatusCode.BadRequest ,"Response is null");
        }
        var weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(
            apiResponse.Content?.ToString(),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return await Task.FromResult(
            new ServiceResult<WeatherApiResponse>(
                true, 
                HttpStatusCode.OK,
                "Success",
                weatherData)
            );
    }
}