using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffold.Domain.Aggregations.UserAggregate.ValueObjects.Login;

[ComplexType]
public class Login
{
    public Login()
    {
    }
    
    public Login(string username, string password)
    {
        Username = username;
        Password = SecretHasher.Hash(password);
    }
    
    public string Username { get; private set; }
    public string Password { get; private set; }
    public bool Blocked { get; private set; }
    public int LoginAttempts { get; private set; }

    public bool Authenticate(string password)
    {
        return SecretHasher.Verify(password, Password);
    }
}