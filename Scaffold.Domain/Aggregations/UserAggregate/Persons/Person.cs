using Scaffold.Domain.Aggregations.UserAggregate.ValueObjects.Documents;
using Scaffold.Domain.Base;
using Scaffold.Domain.Validators.Users;

namespace Scaffold.Domain.Aggregations.UserAggregate.Persons;

public class Person : CreatableAndDeletableEntityBase<Person, PersonValidator>
{
    
    public string Name { get; private set; }
    public Document Document { get; private set; }

    protected Person(int id, string name, string rawDocument)
    {
        Id = id;
        Name = name;
        Document = Document.FromRawNumber(rawDocument).AsDocument();
        Validate();
    }

    public Person() { }
    
    public Person(string name, string rawDocument)
    {
        Name = name;
        Document = Document.FromRawNumber(rawDocument).AsDocument();
        Validate();
    }
    
    public Person WithDocument(string documentNumber)
    {
        Document = Document.FromRawNumber(documentNumber).AsDocument();
        return this;
    }

    public Person HasName(string name)
    {
        Name = name;
        return this;
    }
}
