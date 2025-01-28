namespace Scaffold.Domain.Aggregations.UserAggregate.ValueObjects.Documents;

public interface IDocument
{
    string RawNumber { get; }
    string Formatted();
    string Justified();
    bool IsValid();
    Document AsDocument();
}