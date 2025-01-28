namespace Scaffold.Domain.Aggregations.UserAggregate.ValueObjects.Documents;

public class Cnpj(string rawNumber) : IDocument
{
    public string RawNumber { get; } = rawNumber;
    public string Formatted() => Convert.ToInt64(RawNumber).ToString(@"00\.000\.000/0000\-00");
    public string Justified() => Convert.ToInt64(RawNumber).ToString("00000000000000");
    public bool IsValid() => Document.IsCnpj(RawNumber);
    public Document AsDocument()
    {
        return new Document(RawNumber);
    }
}