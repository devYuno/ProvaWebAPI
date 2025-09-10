using System.ComponentModel.DataAnnotations;
namespace WebTuor.UseCases.Login;

public record LoginPayload
{
    public required string Login { get; init; } // Apenas o username

    public required string Password { get; init; }
}