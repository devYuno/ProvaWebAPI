using System.ComponentModel.DataAnnotations;

namespace WebTuor.UseCases.CreatePasseio;

public record CreatePasseioPayload
{
    public Guid UserId { get; init; }

    [MaxLength(20)]
    public required string Title { get; init; }

    [MinLength(40)]
    [MaxLength(200)]
    public required string Description { get; init; }
}