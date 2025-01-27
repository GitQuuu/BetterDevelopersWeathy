using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Services.WeatherService;

// Each method defined in the main interface file will reside in its own respected folder, representing a feature
public partial class WeatherBll
{
    public async Task<IActionResult> GetWeatherDataAsync(string city, uint days, string language, CancellationToken ct)
    {
        var referer = _httpContextAccessor.HttpContext.Request.Headers["Referer"].ToString();

        if (referer is "http://localhost:4200/" or "https://betterweathy.netlify.app/")
        {
            var weatherApiResponse = await _weatherApiWebService.ForeCastAsync(city, days, language, ct);

            var response = await _weatherService.HandleWeatherDataAsync(weatherApiResponse,ct);
        
            return await _responseService.HandleResultAsync(response);
        }
        else
        {
            var nameIdentifier = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(nameIdentifier))
            {
                return Unauthorized();
            }
            var weatherApiResponse = await _weatherApiWebService.ForeCastAsync(city, days, language, ct);

            var response = await _weatherService.HandleWeatherDataAsync(weatherApiResponse,ct);
        
            return await _responseService.HandleResultAsync(response);
        }
    
    }
}