using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.AccountService;

namespace Api.Controllers.AccountController.v2;

public partial class AccountController
{
    /// <summary>
    /// Registration endpoint for an account  version 2
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        // This is using the same bll, just to show that vesion 2 endpoint works and hows its done
        return Ok();
    }
}