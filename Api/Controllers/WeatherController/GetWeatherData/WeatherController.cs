using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.WeatherController;

public partial class WeatherController
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="query">Can be anything from city name, zipcode, latitude and longiu</param>
    /// <param name="days"> number of days ahead to be forecasted</param>
    /// <param name="language">specify a preferred language</param>///
    /// <returns></returns>
    /// <remarks>
    ///     GET /api/weather?query=56.1518,10.2064&days=7&language=dk
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> GetWeatherData(string query, int days, string language)
    {
        return await _weatherBll.GetWeatherDataAsync(query, days, language);
    }
}