using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountController;

/// <summary>
/// Auth endpoint
/// </summary>
[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public partial class AccountController : ControllerBase
{
    
}