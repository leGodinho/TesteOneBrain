using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Domain.Dtos.Orders.Create;
using Scaffold.Domain.Interfaces.Services;

namespace Scaffold.Web.Routes;

public static class MapTableRoutesExtension
{
    public static WebApplication MapTableRoutes(this WebApplication app)
    {
        app.MapGet("/table/{tableId}", async ([FromServices] ITableService tableService, int tableId)
                => await tableService.GetDetails(tableId))
            .WithTags("Table")
            .RequireAuthorization()
            .WithOpenApi();

        return app;
    }
}