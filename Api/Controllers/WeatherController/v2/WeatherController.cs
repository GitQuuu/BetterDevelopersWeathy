using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.WeatherController.v2;

[ApiController]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet]
    [Route("TestVersioning")]
    public async Task<IActionResult> TestEndpoint()
    {
        return Ok("Endpoint works for version 2.0");
    }
}