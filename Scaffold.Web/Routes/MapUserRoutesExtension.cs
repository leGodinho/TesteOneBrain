using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Domain.Dtos.Users.Create;
using Scaffold.Domain.Dtos.Users.Update;
using Scaffold.Domain.Interfaces.Services;

namespace Scaffold.Web.Routes;

public static class MapUserRoutesExtension
{
    public static WebApplication MapUserRoutes(this WebApplication app)
    {
        app.MapPost("/user/{RouteGroup}", async (ClaimsPrincipal currentUser, [FromServices] IUserService userService,
                    [FromBody] CreateUserRequest request)
                => await userService.Create(request))
            .WithTags("User")
            .RequireAuthorization()
            .WithOpenApi();

        app.MapGet("/user", async ([FromServices] IUserService userService)
                => await userService.List(""))
            .WithTags("User")
            .RequireAuthorization()
            .WithOpenApi();

        app.MapGet("/user/{id}", async ([FromServices] IUserService userService, 
                    [FromQuery] int id)
                => await userService.Get(id))
            .WithTags("User")
            .RequireAuthorization()
            .WithOpenApi();

        app.MapDelete("/user/{id}", async ([FromServices] IUserService userService, 
                    [FromQuery] int id)
                => await userService.Delete(id))
            .WithTags("User")
            .RequireAuthorization()
            .WithOpenApi();

        app.MapPut("/user/{id}", async ([FromServices] IUserService userService, 
                    [FromBody] UpdateUserRequest request)
                => await userService.Update(request))
            .WithTags("User")
            .RequireAuthorization()
            .WithOpenApi();
        
        return app;
    }
    
}