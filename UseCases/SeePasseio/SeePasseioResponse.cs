namespace WebTuor.UseCases.SeePasseio;

public record SeePasseioResponse(
    string Title,
    string Description,
    string CreatorName,
    IEnumerable<NamePoints> NamePoints
);

public record NamePoints
{
    public string Name { get; set; }
}