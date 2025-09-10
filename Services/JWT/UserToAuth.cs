namespace WebTuor.Services.JWT;

public record UserToAuth(
    Guid UserId,
    string Username
);