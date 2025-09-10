using System.ComponentModel.DataAnnotations;

namespace WebTuor.UseCases.SeePasseio;

public record SeePasseioPayload
{
    [Required]
    public Guid PasseioId { get; init; }
}