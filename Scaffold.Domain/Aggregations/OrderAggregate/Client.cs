using Scaffold.Domain.Base;
using Scaffold.Domain.Validators.Orders;

namespace Scaffold.Domain.Aggregations.OrderAggregate;

public class Client : EntityBase<Client, ClientValidator>
{
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }

    protected Client()
    {
    }

    public Client(string clientName, string clientPhone)
    {
        Name = clientName;
        PhoneNumber = clientPhone;
        
        Validate();
    }
}