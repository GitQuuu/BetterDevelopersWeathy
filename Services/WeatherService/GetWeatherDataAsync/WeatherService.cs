using System.Net;
using Refit;
using Services.External.WeatherApiWebService;

namespace Services.WeatherService;

public partial class WeatherService
{
    public async Task<ServiceResult<object>> HandleWeatherDataAsync(ApiResponse<object> apiResponse,CancellationToken cancellationToken)
    {
        var data = apiResponse.Content;
       
        return new ServiceResult<object>(true, HttpStatusCode.OK,data);
    }
}