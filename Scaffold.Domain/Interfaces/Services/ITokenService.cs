using Scaffold.Domain.Dtos.Users.GetToken;

namespace Scaffold.Domain.Interfaces.Services;

public interface ITokenService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
}