using Microsoft.AspNetCore.Identity;

namespace Services.SignInManagerService;

public partial interface ISignInManagerService
{
    Task<SignInResult> PasswordSignInAsync(string dtoEmail, string dtoPassword, bool isPersistent, bool lockoutOnFailure);
}