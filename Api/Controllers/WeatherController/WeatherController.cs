using Microsoft.AspNetCore.Mvc;
using Services.WeatherService;

namespace Api.Controllers.WeatherController;

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