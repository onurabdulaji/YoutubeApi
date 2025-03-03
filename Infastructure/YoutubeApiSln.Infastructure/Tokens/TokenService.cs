using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiSln.Application.Interfaces.Tokens;
using YoutubeApiSln.Domain.Entitites;

namespace YoutubeApiSln.Infastructure.Tokens;

public class TokenService : ITokenService
{
    private readonly TokenSettings tokenSettings;
    private readonly UserManager<User> userManager;

    public TokenService(IOptions<TokenSettings> options, UserManager<User> userManager)
    {
        this.userManager = userManager;
        tokenSettings = options.Value;

    }
    public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email,user.Email)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));

        var token = new JwtSecurityToken(
            issuer: tokenSettings.Issuer,
            audience: tokenSettings.Audience,
            expires: DateTime.Now.AddMinutes(tokenSettings.TokenValidityInMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

        await userManager.AddClaimsAsync(user, claims);

        return token;

    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken()
    {
        throw new NotImplementedException();
    }
}
