using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.UserManagerService;

namespace Services.AccountService;

public partial class AccountService : IAccountService
{
    private readonly IUserManagerService _userManagerService;
    private readonly IConfiguration _configuration;

    public AccountService(IUserManagerService userManagerService, IConfiguration configuration)
    {
        _userManagerService = userManagerService;
        _configuration = configuration;
    }
    
    private async Task<JwtSecurityToken> GenerateJwtSecurityToken(IdentityUser? user)
    {
        _ = int.TryParse(_configuration["Jwt:TokenValidityInMinutes"], out int tokenValidityInMinutes);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException()));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id),
            new (ClaimTypes.Email, user.Email ?? ""),
            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new (JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
        };

        var token = new JwtSecurityToken(_configuration["Jwt:issuer"] ?? throw new InvalidOperationException()
            , _configuration["Jwt:audience"] ?? throw new InvalidOperationException(),
            claims,
            null,
            expires : DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
            signingCredentials : credentials
        );

        return await Task.FromResult(token);
    }
   
}