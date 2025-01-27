

using Microsoft.AspNetCore.Identity;

namespace Services.UserManagerService;

public partial class UserManagerService : IUserManagerService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserManagerService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
}