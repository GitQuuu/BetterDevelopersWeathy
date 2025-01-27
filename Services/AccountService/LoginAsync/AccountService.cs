using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace Services.AccountService;

public partial class AccountService
{
    public async Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        var result = await _signInManagerService.PasswordSignInAsync(dto.Email, dto.Password, false, false);

        if (result.Succeeded is false)
        {
            return new ServiceResult<LoginResponseDto>(false, HttpStatusCode.Unauthorized, "Email or password is incorrect");
        }
        
        var user = await _userManagerService.FindByEmailAsync(dto.Email);
        if (user.Data is null)
        {
            return new ServiceResult<LoginResponseDto>(false, HttpStatusCode.Unauthorized, "No such user");
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