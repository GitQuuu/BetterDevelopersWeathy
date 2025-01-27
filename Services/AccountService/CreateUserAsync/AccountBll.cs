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
        
        //ToDo Add emailservice here  in the future , with callback for account activation
        
        return await _responseService.HandleResultAsync(initUser);
    }
}