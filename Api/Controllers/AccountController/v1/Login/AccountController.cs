using Api.Controllers.AccountController.v1.Login;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.AccountService;

namespace Api.Controllers.AccountController.v1;

public partial class AccountController
{
    /// <summary>
    /// Login endpoint for the client
    /// </summary>
    /// <param name="payload">The request payload</param>
    /// <returns>Json web token</returns>
    [HttpPost]
    [Route("Login")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody]LoginRequest payload)
    {
        return await _accountBll.LoginAsync(payload.Adapt<LoginRequestDto>());
    }
}