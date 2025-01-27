using System.Net;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Services.AccountService;

namespace Services.UserManagerService;

public partial class UserManagerService : IUserManagerService
{
    public async Task<ServiceResult<IdentityUser>> CreateUserAsync(CreateUserRequestDto dto, string dtoPassword, CancellationToken token)
    {
        IdentityUser userRegistration = new();
        dto.Adapt(userRegistration);	
		
        var result = await _userManager.CreateAsync(userRegistration, dtoPassword);
		
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                // _logger.LogError("Error during registration {Error} {Description}",error.Code, error.Description);
            }

            return new ServiceResult<IdentityUser>(false,
                HttpStatusCode.Conflict,
                String.Join(", ", result.Errors.Select(x => x.Code + " - " + x.Description)));
        }

        return new ServiceResult<IdentityUser>(true, HttpStatusCode.Created, "User created", userRegistration);
    }
}