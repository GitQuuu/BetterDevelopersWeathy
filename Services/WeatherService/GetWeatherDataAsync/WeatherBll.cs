using System.Text.Json;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.External.WeatherApiWebService;

namespace Services.WeatherService;

public partial class WeatherBll
{
    public async Task<IActionResult> GetWeatherDataAsync(string city, int days, string language, CancellationToken ct)
    {
        var apiResponse = await _weatherApiWebService.ForeCastAsync(city, days, language, ct);

        // Deserialize JSON content to WeatherResponse model
        var weatherData = JsonSerializer.Deserialize<WeatherApiResponse>(
            apiResponse.Content.ToString(),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        var response = await _weatherService.HandleWeatherDataAsync(apiResponse,ct);
        
        return Ok(response.Data);
    }

}