using Microsoft.AspNetCore.Mvc;
using Services.External.WeatherApiWebService;
using Services.WeatherService;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWeatherBll _weatherBll;


    public HomeController(ILogger<HomeController> logger, IWeatherBll weatherBll)
    {
        _logger = logger;
        _weatherBll = weatherBll;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string city, int days, string language)
    {
        var response = await _weatherBll.GetWeatherDataAsync(city, days, language);
        return Ok(response);
    }
   
}