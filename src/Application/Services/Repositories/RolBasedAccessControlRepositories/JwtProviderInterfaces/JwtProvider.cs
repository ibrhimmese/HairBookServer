using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Login;
using Domain.Entities.RolBasedAccessControlEntities;
using IMFrameworkCore;
using Infrastructure.RoleBasedAccessControl.JwtOptionSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services.Repositories.RolBasedAccessControlRepositories.JwtProviderInterfaces;

public class JwtProvider : IJwtProvider 
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<User> _userManager;

    public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager)
    {
        _jwtOptions = jwtOptions.Value;
        _userManager = userManager;
    }

    public async Task<LoginCommandResponse> CreateTokenAsync(User user)
    {
        var claims = new Claim[]
        {
            //new Claim(ClaimTypes.NameIdentifier,user.Id),
            //new Claim(JwtRegisteredClaimNames.Name,user.UserName),
            //new Claim("Name",user.UserName)

        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // Kullanıcı adı için Sub claim'i ekleyin
        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName), // Kullanıcı adı için UniqueName claim'i ekleyin
        new Claim(ClaimTypes.Email, user.Email),
        new Claim("fullName", user.FullName),
        new Claim("userName", user.UserName),
        };

        DateTime expires = DateTime.Now.AddHours(1);
        JwtSecurityToken jwtToken = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha512)
            );

        string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = expires.AddMinutes(15);
        await _userManager.UpdateAsync(user);

        LoginCommandResponse response = new(
            token,
            refreshToken,
           user.RefreshTokenExpires,
            user.Id

            );
        return response;
    }
}
