using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Services.AccountService;

namespace Api.Controllers.AccountController.v2;

/// <summary>
/// Auth endpoint version 2
/// </summary>
[ApiController]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public partial class AccountController : ControllerBase
{
    private readonly IAccountBll _accountBll;

    public AccountController(IAccountBll accountBll)
    {
        _accountBll = accountBll;
    }
}