using Microsoft.AspNetCore.Mvc;

namespace Services.WeatherService;

public interface IWeatherBll
{
    Task<IActionResult> GetWeatherDataAsync(string city, uint days, string language,
        CancellationToken cancellationToken = default);
}