using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Services.AccountService;

namespace Api.Controllers.AccountController.v1;

/// <summary>
/// Auth endpoint
/// </summary>
[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public partial class AccountController : ControllerBase
{
    private readonly IAccountBll _accountBll;

    /// <inheritdoc />
    public AccountController(IAccountBll accountBll)
    {
        _accountBll = accountBll;
    }
}