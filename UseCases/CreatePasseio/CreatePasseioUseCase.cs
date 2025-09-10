using WebTuor.Models;
using WebTuor.Services.Users;

namespace WebTuor.UseCases.CreatePasseio;

public class CreatePasseioUseCase(IUsersService usersService, WebTuorDbContext ctx)
{
    public async Task<Result<CreatePasseioResponse>> Do(CreatePasseioPayload payload)
    {
        var user = await usersService.FindById(payload.UserId);

        var passeio = new Passeio
        {
            Title = payload.Title,
            Description = payload.Description,
            OwnerId = payload.UserId
        };

        if(passeio is null)
            return Result<CreatePasseioResponse>.Fail("Não pode ser nulo"); // Não sabia escrever isso em ingles xD

        ctx.Passeio.Add(passeio);

        user.Passeios.Add(passeio);

        await ctx.SaveChangesAsync();

        return Result<CreatePasseioResponse>.Success(new(passeio.Id));
    }

}