using Microsoft.AspNetCore.Mvc;
using Services.External.WeatherApiWebService;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWeatherApiWebService _weatherApiWebService;

    public HomeController(ILogger<HomeController> logger, IWeatherApiWebService weatherApiWebService)
    {
        _logger = logger;
        _weatherApiWebService = weatherApiWebService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string city, int days, string language)
    {
        var response = await _weatherApiWebService.ForeCastAsync(city, days, language);
        return Ok(response.Content);
    }
   
}