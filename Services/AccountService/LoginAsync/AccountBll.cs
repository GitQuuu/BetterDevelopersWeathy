using Microsoft.AspNetCore.Mvc;

namespace Services.AccountService;

public partial class AccountBll
{
    public async Task<IActionResult> LoginAsync(LoginRequestDto dto)
    {
        var result = await _accountService.LoginAsync(dto);

        return await _responseService.HandleResultAsync(result);
    }
}