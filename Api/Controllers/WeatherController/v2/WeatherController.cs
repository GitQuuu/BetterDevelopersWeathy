using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.WeatherController.v2;

[ApiController]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class WeatherController : ControllerBase
{
    /// <summary>
    /// Testing endpoint for versioning
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("TestVersioning")]
    public async Task<IActionResult> TestEndpoint()
    {
        return await Task.FromResult(Ok("Endpoint works for version 2.0"));
    }

    /// <summary>
    /// Protected endpoint get access by jwt
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("GetAccess")]
    [Authorize]
    public async Task<IActionResult> GetAccess()
    {
        return await Task.FromResult(Ok("Successfully access protected endpoint"));
    }
}