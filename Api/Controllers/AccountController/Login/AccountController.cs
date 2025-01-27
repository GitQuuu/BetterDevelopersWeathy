

using System.ComponentModel.DataAnnotations;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountController;

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
        var response = await _accountBll.LoginAsync(payload.Adapt<LoginRequestDto>());
        return response.Adapt<ActionResult>();
    }
}

public class LoginRequest
{
    /// <summary>
    /// The email registration is also the username
    /// </summary>
    [Required]
    public required string Email { get; set; }
	
    /// <summary>
    /// The user password
    /// </summary>
    [Required]
    public required string Password { get; set; }
}