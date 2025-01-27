using Microsoft.AspNetCore.Identity;

namespace Services.SignInManagerService;

public partial class SignInManagerService : ISignInManagerService
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public SignInManagerService(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }
   
}