using Microsoft.AspNetCore.Mvc;

namespace Services.AccountService;

public partial interface IAccountBll
{
    Task<ActionResult> CreateUserAsync(CreateUserRequestDto adapt);
}