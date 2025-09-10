using System.ComponentModel.DataAnnotations;

namespace WebTuor.UseCases.CreatePasseio;

public record CreatePasseioPayload
{
    public Guid UserId { get; init; }

    [Required]
    [MaxLength(20)]
    public string Title { get; init; }

    [Required]
    [MinLength(40)]
    [MaxLength(200)]
    public string Description { get; init; }
}