namespace Scaffold.Domain.Aggregations.UserAggregate.ValueObjects.Documents;

public class RawDocument(string rawNumber) : IDocument
{
    public string RawNumber { get; } = rawNumber;
    public string Formatted() => RawNumber;
    public string Justified() => RawNumber;
    public bool IsValid() => true;
    
    public Document AsDocument()
    {
        return new Document(RawNumber);
    }
}