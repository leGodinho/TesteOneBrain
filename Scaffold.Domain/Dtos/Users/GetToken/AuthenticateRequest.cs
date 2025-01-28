namespace Scaffold.Domain.Dtos.Users.GetToken;

public record AuthenticateRequest(string UserName, string Password);