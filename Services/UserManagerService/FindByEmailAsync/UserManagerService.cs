using System.Net;
using Microsoft.AspNetCore.Identity;

namespace Services.UserManagerService;

public partial class UserManagerService
{
    public async Task<ServiceResult<IdentityUser>> FindByEmailAsync(string dtoEmail)
    {
        var result = await _userManager.FindByEmailAsync(dtoEmail);
        if (result is null)
        {
            return new ServiceResult<IdentityUser>(false, HttpStatusCode.NotFound, "Not Found");
        }

        return new ServiceResult<IdentityUser>(true, HttpStatusCode.OK, "Found the user", result);
    }
}