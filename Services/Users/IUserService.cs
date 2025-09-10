using WebTuor.Models;

namespace WebTuor.Services.Users;

public interface IUsersService
{
    Task<User> FindByLogin(string login);
    Task<User> FindById(Guid id);

}