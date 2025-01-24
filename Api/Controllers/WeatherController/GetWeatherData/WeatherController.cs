using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.WeatherController;

public partial class WeatherController
{
    [HttpGet]
    public async Task<IActionResult> GetWeatherData(string city, int days, string language)
    {
        return await _weatherBll.GetWeatherDataAsync(city, days, language);
    }
}