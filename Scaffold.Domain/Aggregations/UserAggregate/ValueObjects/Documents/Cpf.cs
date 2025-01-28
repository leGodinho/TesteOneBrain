namespace Scaffold.Domain.Aggregations.UserAggregate.ValueObjects.Documents;

public class Cpf(string rawNumber) : IDocument
{
    public string RawNumber { get; } = rawNumber;

    public string Formatted() => Convert.ToInt64(RawNumber).ToString(@"000\.000\.000\-00");
    public string Justified() => Convert.ToInt64(RawNumber).ToString(@"00000000000");
    public bool IsValid() => Document.IsCpf(RawNumber);
    public Document AsDocument()
    {
        return new Document(RawNumber);
    }
}