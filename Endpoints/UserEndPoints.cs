
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using WebTuor.UseCases.CreatePasseio;
using WebTuor.UseCases.EditPasseio;
using WebTuor.UseCases.SeePasseio;

namespace WebTuor.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        //Criar Passeio
        app.MapPost("user/passeio/", async (
            HttpContext http,
            [FromBody] CreatePasseioPayload payload,
            [FromServices] CreatePasseioUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            payload = payload with { UserId = userId };
            var result = await useCase.Do(payload);

            return Results.Created($"/passeio/{result.Data.PasseioId}", result);
        }).RequireAuthorization();


        //Editar passeio
        app.MapPut("user/passeio/{id}", async (
            Guid id,
            HttpContext http,
            [FromBody] EditPasseioPayload payload,
            [FromServices] EditPasseioUseCase useCase
        ) =>
        {
            var userIdClaim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            payload = payload with
            {
                UserId = userId,
                PasseioId = id
            };

            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "Passeio not found!") => Results.NotFound(),
                (false, "Tuor Point not found!") => Results.NotFound(),
                (false, "You not have permissions") => Results.Unauthorized(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Created($"/visita/{result.Data.VisitaId}", result)
            };

        }).RequireAuthorization();


        // See Passeios
        app.MapGet("passeios/{id}", async (
           Guid id,
           [FromServices] SeePasseioUseCase useCase) =>
        {
            var payload = new SeePasseioPayload { PasseioId = id };
            var response = await useCase.Do(payload);

            return (response.IsSuccess, response.Reason) switch
            {
                (false, "Passeio not found!") => Results.NotFound(response.Reason),
                (false, _) => Results.BadRequest(response.Reason),
                (true, _) => Results.Ok(response.Data)
            };
        });
    }
}