using Microsoft.EntityFrameworkCore;
using WebTuor.Models;

namespace WebTuor.UseCases.SeePasseio;

public class SeePasseioUseCase(WebTuorDbContext ctx)
{
    public async Task<Result<SeePasseioResponse>> Do(SeePasseioPayload payload)
    {
        var passeio = await ctx.Passeio.FirstOrDefaultAsync(p => p.Id == payload.PasseioId);

        if(passeio is null)
            return Result<SeePasseioResponse>.Fail("Passeio not found!");

        var namepoints = ctx.Visita
            .Where(v => v.PasseioId == passeio.Id)
            .Select(v => new NamePoints
            {
                Name = v.PontoTuristico.Title
            });

        var result = new SeePasseioResponse(
            passeio.Title,
            passeio.Description,
            passeio.Owner.NameFull,
            namepoints
        );
        return Result<SeePasseioResponse>.Success(result);
    }

}