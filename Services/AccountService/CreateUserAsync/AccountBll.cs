using Microsoft.AspNetCore.Mvc;

namespace Services.AccountService;

public partial class AccountBll
{
    public async Task<IActionResult> CreateUserAsync(CreateUserRequestDto dto, CancellationToken token)
    {
        var initUser = await _accountService.Registration(dto, token);
        if (initUser.Data is null)
        {
            return await _responseService.HandleResultAsync(initUser);
        }
        
        return await _responseService.HandleResultAsync(initUser);
    }
}