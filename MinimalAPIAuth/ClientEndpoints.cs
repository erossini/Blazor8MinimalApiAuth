using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using MinimalAPIAuth.Shared.Models;

namespace MinimalAPIAuth;

public static class ClientEndpoints
{
    public static void MapClientEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Client").WithTags(nameof(Client));

        group.MapGet("/", () =>
        {
            return new[] { new Shared.Models.Client() { FirstName = "Enrico", Id = 1, LastName = "Rossini" } };
        })
        .RequireAuthorization()
        .WithName("GetAllClients")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new Client { ID = id };
        })
        .WithName("GetClientById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, Shared.Models.Client input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateClient")
        .WithOpenApi();

        group.MapPost("/", (Shared.Models.Client model) =>
        {
            //return TypedResults.Created($"/api/Clients/{model.ID}", model);
        })
        .WithName("CreateClient")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new Client { ID = id });
        })
        .WithName("DeleteClient")
        .WithOpenApi();
    }
}
