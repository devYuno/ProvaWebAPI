using Microsoft.EntityFrameworkCore;
using WebTuor.Models;

namespace WebTuor.Services.Users;

public class EFUserService(WebTuorDbContext ctx) : IUsersService
{
    public async Task<User> FindByLogin(string login)
    {
        var user = await ctx.User.FirstOrDefaultAsync(
            p => p.Username == login
        );
        return user;

    }
    public async Task<User> FindById(Guid id)
    {
        var user = await ctx.User.FirstOrDefaultAsync(
            p => p.Id == id
        );
        return user;
    }
}