using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.AccountService;

namespace Api.Controllers.AccountController;

public partial class AccountController
{
    /// <summary>
    /// Registration endpoint for an account
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        return await _accountBll.CreateUserAsync(request.Adapt<CreateUserRequestDto>());
    }
}