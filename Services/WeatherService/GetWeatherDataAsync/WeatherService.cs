using System.Net;
using Refit;
using Services.External.WeatherApiWebService.ForeCastAsync;

namespace Services.WeatherService;

public partial class WeatherService
{
    public async Task<ServiceResult<WeatherApiResponse>> HandleWeatherDataAsync(
        ApiResponse<WeatherApiResponse> apiResponse,
        CancellationToken cancellationToken)
    {
        if (apiResponse.IsSuccessful is false)
        {
            return new ServiceResult<WeatherApiResponse>(false, apiResponse.StatusCode , apiResponse.Error.Content);
        }
     
        return await Task.FromResult(
            new ServiceResult<WeatherApiResponse>(
                true, 
                HttpStatusCode.OK,
                "Success",
                apiResponse.Content)
            );
    }
}