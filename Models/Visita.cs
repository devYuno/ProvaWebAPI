// Tabela intermediaria entre passeios e pontos turisticos

namespace WebTuor.Models;

public class Visita
{
    public Guid Id { get; set; }
    public Guid PasseioId { get; set; }
    public Passeio Passeio { get; set; }
    public PontoTuristico PontoTuristico { get; set; }
    public Guid PontoTuristicoId { get; set; }
}