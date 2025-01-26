using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Services.WeatherService;

namespace Api.Controllers.WeatherController.v1;

/// <summary>
/// Endpoint for weather, handles request and return response
/// </summary>
[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public partial class WeatherController
{
    private readonly IWeatherBll _weatherBll;

    public WeatherController(IWeatherBll  weatherBll)
    {
        _weatherBll = weatherBll;
    }
}