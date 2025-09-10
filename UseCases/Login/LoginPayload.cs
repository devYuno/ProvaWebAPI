using System.ComponentModel.DataAnnotations;
namespace WebTuor.UseCases.Login;

public record LoginPayload
{
    [Required]
    public string Login { get; init; } // Apenas o username

    [Required]
    public string Password { get; init; }
}