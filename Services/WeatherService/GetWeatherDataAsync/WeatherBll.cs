using Microsoft.AspNetCore.Mvc;

namespace Services.WeatherService;

public partial class WeatherBll
{
    public async Task<IActionResult> GetWeatherDataAsync(string city, uint days, string language, CancellationToken ct)
    {
        var weatherApiResponse = await _weatherApiWebService.ForeCastAsync(city, days, language, ct);

        var response = await _weatherService.HandleWeatherDataAsync(weatherApiResponse.Content,ct);
        
        return await _responseService.HandleResultAsync(response);
    
    }

}