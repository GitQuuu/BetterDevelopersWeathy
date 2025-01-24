using System.Net;
using Services.External.WeatherApiWebService.ForeCastAsync;

namespace Services.WeatherService;

public partial class WeatherService
{
    public async Task<ServiceResult<WeatherApiResponse>> HandleWeatherDataAsync(WeatherApiResponse? apiResponse,
        CancellationToken cancellationToken)
    {
        if (apiResponse is null)
        {
            return new ServiceResult<WeatherApiResponse>(false, HttpStatusCode.BadRequest ,"Response is null");
        }
     
        return await Task.FromResult(
            new ServiceResult<WeatherApiResponse>(
                true, 
                HttpStatusCode.OK,
                "Success",
                apiResponse)
            );
    }
}