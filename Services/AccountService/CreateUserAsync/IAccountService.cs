using Microsoft.AspNetCore.Identity;

namespace Services.AccountService;

public partial interface IAccountService
{
    Task<ServiceResult<IdentityUser?>> Registration(CreateUserRequestDto dto, CancellationToken token);
}