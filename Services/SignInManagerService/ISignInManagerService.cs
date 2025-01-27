using Microsoft.AspNetCore.Identity;

namespace Services.SignInManagerService;

public interface ISignInManagerService
{
    Task<SignInResult> PasswordSignInAsync(string dtoEmail, string dtoPassword, bool b, bool b1);
}