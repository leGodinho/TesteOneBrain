using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Domain.Dtos.Orders.Create;
using Scaffold.Domain.Interfaces.Services;

namespace Scaffold.Web.Routes;

public static class MapOrderRoutesExtension
{
    public static WebApplication MapOrderRoutes(this WebApplication app)
    {
        app.MapPost("/order/{RouteGroup}", async (ClaimsPrincipal currentUser, 
                    [FromServices] IOrderService orderService,
                    [FromBody] CreateOrderRequest request)
                => await orderService.Create(request))
            .WithTags("Order")
            .RequireAuthorization()
            .WithOpenApi();

        app.MapGet("/order", async ([FromServices] IOrderService orderService)
                => await orderService.ListOpenOrder())
            .WithTags("Order")
            .RequireAuthorization()
            .WithOpenApi();

        return app;
    }
}