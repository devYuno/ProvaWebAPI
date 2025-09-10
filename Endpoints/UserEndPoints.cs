
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebTuor.UseCases.CreatePasseio;

namespace WebTuor.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapPost("user/{id}/passeio/", async (
            Guid id,
            HttpContext http,
            [FromBody] CreatePasseioPayload payload,
            [FromServices] CreatePasseioUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            var result = await useCase.Do(payload);
            return Results.Created($"/passeio/{result.Data.PasseioId}", result);
        }).RequireAuthorization();
    }
}