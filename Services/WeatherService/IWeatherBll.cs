using Microsoft.AspNetCore.Mvc;

namespace Services.WeatherService;

public interface IWeatherBll
{
    Task<IActionResult> GetWeatherDataAsync(string city, int days, string language, CancellationToken cancellationToken = default);
}