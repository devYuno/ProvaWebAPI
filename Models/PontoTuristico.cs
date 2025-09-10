namespace WebTuor.Models;

public class PontoTuristico
{
    public Guid Id { get; set; }
    public required string Title { get; set; }

    public ICollection<Visita> Visitas = [];
}