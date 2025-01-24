using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.WeatherController;

public partial class WeatherController
{
    /// <summary>
    /// Get weather forecast data
    /// </summary>
    /// <param name="query">Can be name of city or latitude and longitude</param>
    /// <param name="days"> number of days ahead to be forecasted ( only positive numbers allowed )</param>
    /// <param name="language">specify a preferred language</param>///
    /// <returns>
    /// Returns an HTTP response with the weather forecast data. If successful, 
    /// the response contains weather details in JSON format. If the request 
    /// is invalid, a 400 Bad Request is returned.
    /// </returns>
    /// <remarks>
    /// Example: GET /api/weather?query=56.1518,10.2064&amp;days=7&amp;language=dk <br />
    /// Example: GET /api/weather?query=Århus&amp;days=2&amp;language=dk
    /// </remarks>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetWeatherData(string query, uint days, string language)
    {
        return await _weatherBll.GetWeatherDataAsync(query, days, language);
    }
}