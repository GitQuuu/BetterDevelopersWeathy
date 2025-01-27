using Microsoft.AspNetCore.Identity;

namespace Services.SignInManagerService;

public class SignInManagerService : ISignInManagerService
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public SignInManagerService(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }
    public async Task<SignInResult> PasswordSignInAsync(string dtoEmail, string dtoPassword, bool isPersistent, bool lockoutOnFailure)
    {
        return await _signInManager.PasswordSignInAsync(dtoEmail, dtoPassword, isPersistent, lockoutOnFailure);
    }
}