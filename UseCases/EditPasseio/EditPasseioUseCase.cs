using Microsoft.EntityFrameworkCore;
using WebTuor.Models;
using WebTuor.Services.Users;

namespace WebTuor.UseCases.EditPasseio;

public class EditPasseioUseCase(WebTuorDbContext ctx)
{
    public async Task<Result<EditPasseioResponse>> Do(EditPasseioPayload payload)
    {

        var passeio = await ctx.Passeio.FirstOrDefaultAsync(p => p.Id == payload.PasseioId);

        if(passeio is null)
            return Result<EditPasseioResponse>.Fail("Passeio not found!");

        var ponto = await ctx.PontoTuristico.FirstOrDefaultAsync(pt => pt.Id == payload.PontoTuristicoId);

        if(ponto is null)
            return Result<EditPasseioResponse>.Fail("Tuor Point not found!");

        if(passeio.OwnerId != payload.UserId)
            return Result<EditPasseioResponse>.Fail("You not have permissions");

        var visita = new Visita
        {
            PasseioId = passeio.Id,
            Passeio = passeio,
            PontoTuristicoId = ponto.Id,
            PontoTuristico = ponto
        };

        ctx.Visita.Add(visita);
        passeio.Visitas.Add(visita);
        ponto.Visitas.Add(visita);

        await ctx.SaveChangesAsync();

        return Result<EditPasseioResponse>.Success(new(visita.Id));
    }

}