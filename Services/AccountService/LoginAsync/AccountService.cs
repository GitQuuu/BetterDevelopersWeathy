using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace Services.AccountService;

public partial class AccountService
{
    public async Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userManagerService.FindByNameAsync(dto.Email);
        if (user.Data is null)
        {
            return new ServiceResult<LoginResponseDto>(false, HttpStatusCode.Unauthorized, "Email or password is incorrect");
        }

        if (user.Data.EmailConfirmed is false)
        {
            return new ServiceResult<LoginResponseDto>(false, HttpStatusCode.Unauthorized, "Your account hasn't been activated yet. Please check your email inbox or spam");
        }

        var result = await _signInManagerService.PasswordSignInAsync(dto.Email, dto.Password, false, false);

        if (result.Succeeded is false)
        {
            return new ServiceResult<LoginResponseDto>(false, HttpStatusCode.Unauthorized, "Email or password is incorrect");
        }

        var accessToken  = await GenerateAccessTokenAsync(user.Data);

        return new ServiceResult<LoginResponseDto>(true, HttpStatusCode.OK, "Login authorized", new LoginResponseDto() { AccessToken = accessToken });
    }

    private async Task<string> GenerateAccessTokenAsync(IdentityUser? user)
    {
        var jwtSecurityToken = await GenerateJwtSecurityToken(user);
        var accessToken      = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        return await Task.FromResult(accessToken);
    }
}