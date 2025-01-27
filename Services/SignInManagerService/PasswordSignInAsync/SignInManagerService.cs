using Microsoft.AspNetCore.Identity;

namespace Services.SignInManagerService;

public partial class SignInManagerService
{
    public async Task<SignInResult> PasswordSignInAsync(string dtoEmail, string dtoPassword, bool isPersistent, bool lockoutOnFailure)
    {
        return await _signInManager.PasswordSignInAsync(dtoEmail, dtoPassword, isPersistent, lockoutOnFailure);
    }
}