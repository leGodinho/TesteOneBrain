using Microsoft.AspNetCore.Mvc;
using Scaffold.Domain.Dtos.Users.GetToken;
using Scaffold.Domain.Interfaces.Services;

namespace Scaffold.Web.Routes;

public static class MapAuthRoutesExtension
{
    public static WebApplication MapAuthRoutes(this WebApplication app)
    {
        app.MapPost("/token", async ([FromServices] ITokenService tokenService, AuthenticateRequest authenticateRequest)
                => await tokenService.Authenticate(authenticateRequest))
            .WithTags("Auth")
            .AllowAnonymous()
            .WithOpenApi();
        
        return app;
    }
}