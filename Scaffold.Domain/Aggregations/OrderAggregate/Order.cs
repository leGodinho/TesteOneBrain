using Scaffold.Domain.Base;
using Scaffold.Domain.Interfaces.Aggregate;
using Scaffold.Domain.Validators.Orders;

namespace Scaffold.Domain.Aggregations.OrderAggregate;

public class Order : EntityBase<Order, OrderValidator>, IAggregateRoot
{
    public virtual  Table Table { get; private set; }
    public virtual IEnumerable<Dish> Dishes { get; private set; } = new List<Dish>();
    public virtual IEnumerable<Drink> Drinks { get; private set; } = new List<Drink>();
    public virtual  Client Client { get; private set; }
    public DateTime Open { get; private set; }
    public DateTime? Close { get; private set; }

    protected Order()
    {
        
    }
    
    public Order(Table table)
    {
        Table = table;
        Open = DateTime.Now;
    }

    public void HaveClient(string clientName, string requestClientPhone)
    {
        Client = new Client(clientName, requestClientPhone);
        Validate();
    }
    
    public void HaveClient(Client existingClient)
    {
        Client = existingClient;
        Validate();
    }

    public void OrderDish(Dish? existingDish)
    {
        Dishes.Concat(new[] { existingDish });
    }

    public void OrderDrink(Drink? existingDrink)
    {
        Drinks.Concat(new[] { existingDrink });
    }
}