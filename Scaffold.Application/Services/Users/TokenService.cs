using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Scaffold.Domain.Configurations;
using Scaffold.Domain.Dtos.Users.GetToken;
using Scaffold.Domain.Interfaces.Repositories;
using Scaffold.Domain.Interfaces.Services;

namespace Scaffold.Application.Services.Users;

public class TokenService(IUserRepository userRepository, IOptions<JwtConfiguration> jwtConfiguration) : ITokenService
{
    private JwtConfiguration JwtConfiguration { get; } = jwtConfiguration.Value;

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await userRepository.GetByUsername(request.UserName);

        if (user == null || !user.Login.Authenticate(request.Password))
            throw new InvalidOperationException("Usuário ou senha inválidos");

        var claims = new UserClaims(user.Id, user.Person.Name, user.Person.Document.Formatted());
        
        var result = new AuthenticateResponse(GenerateJwtToken(claims.ToDictionary()));
        return result;
    }

    private string GenerateJwtToken(IDictionary<string, object> claims)
    {
        var bytes = Encoding.UTF8.GetBytes(JwtConfiguration.Key);
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(bytes), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = signingCredentials,
            Audience = JwtConfiguration.Audience,
            Issuer = JwtConfiguration.Issuer,
            Claims = claims
        };
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
        
        return jwtSecurityTokenHandler.WriteToken(token);
    }
}