using System.Net;
using Microsoft.AspNetCore.Identity;

namespace Services.AccountService;

public partial class AccountService
{
    public async Task<ServiceResult<IdentityUser?>> Registration(CreateUserRequestDto dto, CancellationToken token)
    {
        if (dto.Password != dto.PasswordConfirm)
        {
            return new ServiceResult<IdentityUser?>(false, HttpStatusCode.BadRequest, "Password isn't identical");
        }

        var result = await _userManagerService.CreateUserAsync(dto, dto.Password, token);
		
        if (result.Success is false)
        {
            return new ServiceResult<IdentityUser?>(false,HttpStatusCode.Conflict);
        }
		
        return new ServiceResult<IdentityUser?>(result.Success,result.HttpResponse,result.Message,result.Data);
    }
}
