using Scaffold.Domain.Aggregations.UserAggregate.Persons;
using Scaffold.Domain.Aggregations.UserAggregate.Roles;
using Scaffold.Domain.Aggregations.UserAggregate.ValueObjects.Login;
using Scaffold.Domain.Base;
using Scaffold.Domain.Interfaces.Aggregate;
using Scaffold.Domain.Validators.Users;

namespace Scaffold.Domain.Aggregations.UserAggregate;

public class User : CreatableAndDeletableEntityBase<User, UserValidator>, IAggregateRoot
{
    private readonly List<UserRole> _roles = new();
    public Login Login { get; private set; }
    public int PersonId { get; private set; }
    
    public virtual IReadOnlyCollection<UserRole> Roles => _roles;

    public virtual Person Person { get; private set; }
    
    public User(string name, string rawDocumentNumber, string userName, string password)
    {
        Person = new Person(name, rawDocumentNumber);
        Login = new Login(userName, password);
        Validate();
    }
    
    public User(int personId)
    {
        PersonId = personId;
        Validate();
    }

    public User()
    {
    }
    
    private User SetId(int id)
    {
        Id = id;
        return this;
    }

    public static User FromId(int id)
    {
        var user = new User().SetId(id);
        user.Validate();
        return user;

    }
    
    public User Update(string documentNumber, string name)
    {
        Person.WithDocument(documentNumber).HasName(name);
        Validate();
        return this;
    }
}