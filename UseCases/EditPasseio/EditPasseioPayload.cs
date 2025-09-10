using System.ComponentModel.DataAnnotations;

namespace WebTuor.UseCases.EditPasseio;

public record EditPasseioPayload
{
    [Required]
    public Guid UserId { get; init; }

    [Required]
    public Guid PasseioId { get; init; }
    
    [Required]
    public Guid PontoTuristicoId { get; init; }
}