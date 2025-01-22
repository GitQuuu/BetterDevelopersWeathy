using Microsoft.AspNetCore.Mvc;

namespace Services.WeatherService;

public partial class WeatherBll
{
    public async Task<IActionResult> GetWeatherDataAsync(string city, int days, string language, CancellationToken ct)
    {
        var apiresponse = await _weatherApiWebService.ForeCastAsync(city, days, language);
        
        var response = await _weatherService.HandleWeatherDataAsync(apiresponse,ct);
        
        return Ok(response.Data);
    }

}