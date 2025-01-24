using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.WeatherController;

/// <summary>
/// Endpoint for weather
/// </summary>
public partial class WeatherController
{
    /// <summary>
    /// Get weather forecast
    /// </summary>
    /// <param name="query">Can be anything from city name, zipcode, latitude and longitude</param>
    /// <param name="days"> number of days ahead to be forecasted</param>
    /// <param name="language">specify a preferred language</param>///
    /// <returns>
    /// Returns an HTTP response with the weather forecast data. If successful, 
    /// the response contains weather details in JSON format. If the request 
    /// is invalid, a 400 Bad Request is returned.
    /// </returns>
    /// <remarks>
    /// Example: GET /api/weather?query=56.1518,10.2064&amp;days=7&amp;language=dk <br />
    /// Example: GET /api/weather?query=Aalborg&amp;days=2&amp;language=dk
    /// </remarks>
    [HttpGet]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetWeatherData(string query, int days, string language)
    {
        return await _weatherBll.GetWeatherDataAsync(query, days, language);
    }
}