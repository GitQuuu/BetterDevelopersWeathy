using Microsoft.AspNetCore.Mvc;

namespace Services.AccountService;

public partial interface IAccountBll
{
    Task<IActionResult> LoginAsync(LoginRequestDto dto);
}