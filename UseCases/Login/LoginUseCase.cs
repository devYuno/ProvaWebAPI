using WebTuor.Services.Users;
using WebTuor.Services.JWT;

namespace WebTuor.UseCases.Login;

public record LoginUseCase(IUsersService userService, IJWTService jWTService)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await userService.FindByLogin(payload.Login);
        if (user is null)
            return Result<LoginResponse>.Fail("User not found");

        var pass = payload.Password == user.Password;
        
        if (!pass)
            return Result<LoginResponse>.Fail("Incorrect password!");
        
        var jwt = jWTService.CreateToken(new(
            user.Id, user.Username
        ));

        return Result<LoginResponse>.Success(new(jwt));
    }
}

