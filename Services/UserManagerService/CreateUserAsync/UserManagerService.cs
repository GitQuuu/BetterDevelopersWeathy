using System.Net;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Services.AccountService;

namespace Services.UserManagerService;

public partial class UserManagerService : IUserManagerService
{
    public async Task<ServiceResult<IdentityUser>> CreateUserAsync(CreateUserRequestDto dto, CancellationToken token)
    {
        IdentityUser userRegistration = new();
        dto.Adapt(userRegistration);
        userRegistration.UserName = dto.Email;
		
        var result = await _userManager.CreateAsync(userRegistration, dto.Password);
		
        if (!result.Succeeded)
        {
            return new ServiceResult<IdentityUser>(false,
                HttpStatusCode.Conflict,
                String.Join(", ", result.Errors.Select(x => x.Code + " - " + x.Description)));
        }

        return new ServiceResult<IdentityUser>(true, HttpStatusCode.Created, "User created", userRegistration);
    }
}