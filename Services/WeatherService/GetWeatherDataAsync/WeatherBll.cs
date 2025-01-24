using Microsoft.AspNetCore.Mvc;
using Refit;
using Services.External.WeatherApiWebService;

namespace Services.WeatherService;

public partial class WeatherBll
{
    public async Task<IActionResult> GetWeatherDataAsync(string city, int days, string language, CancellationToken ct)
    {
        ApiResponse<WeatherApiResponse> weatherApiResponse = await _weatherApiWebService.ForeCastAsync(city, days, language, ct);

        var response = await _weatherService.HandleWeatherDataAsync(weatherApiResponse.Content,ct);
        
        return await _responseService.HandleResultAsync(response);
    
    }

}