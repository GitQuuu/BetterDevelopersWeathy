using Microsoft.AspNetCore.Mvc;

namespace Services.AccountService;

public partial interface IAccountBll
{
    Task<IActionResult> CreateUserAsync(CreateUserRequestDto dto, CancellationToken token = default);
}