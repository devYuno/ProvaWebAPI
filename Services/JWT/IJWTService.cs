namespace WebTuor.Services.JWT;

public interface IJWTService
{
    string CreateToken(UserToAuth data); 
}