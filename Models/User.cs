namespace WebTuor.Models;

public class User
{
    public Guid Id { get; set; }
    public required string NameFull { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }

    public ICollection<Passeio> Passeios = [];
}