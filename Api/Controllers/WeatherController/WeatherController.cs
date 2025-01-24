using Microsoft.AspNetCore.Mvc;
using Services.WeatherService;

namespace Api.Controllers.WeatherController;

/// <summary>
/// Endpoint for weather, handles request and return response
/// </summary>
[ApiController]
[Route("api/[controller]")]
public partial class WeatherController
{
    private readonly IWeatherBll _weatherBll;

    public WeatherController(IWeatherBll  weatherBll)
    {
        _weatherBll = weatherBll;
    }
}