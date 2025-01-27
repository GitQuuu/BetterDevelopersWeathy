using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.AccountController;

public partial class AccountController
{
    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserRequest request)
    {
        return await _accountBll.CreateUserAsync(request.Adapt<CreateUserRequestDto>());
    }
}

public class CreateUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}