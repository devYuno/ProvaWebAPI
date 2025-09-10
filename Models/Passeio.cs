namespace WebTuor.Models;

public class Passeio
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; }
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }

    public ICollection<Visita> Visitas = [];
}

