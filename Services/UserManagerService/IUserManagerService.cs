using Microsoft.AspNetCore.Identity;
using Services.AccountService;

namespace Services.UserManagerService;

public partial interface IUserManagerService
{
    Task<ServiceResult<IdentityUser>> CreateUserAsync(CreateUserRequestDto dto, CancellationToken token);
}