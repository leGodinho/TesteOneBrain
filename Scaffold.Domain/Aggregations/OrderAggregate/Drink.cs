using Scaffold.Domain.Base;
using Scaffold.Domain.Validators.Orders;

namespace Scaffold.Domain.Aggregations.OrderAggregate;

public class Drink : EntityBase<Drink, DrinkValidator>
{
    public string Name { get; private set; }
    public double Value { get; private set; }

    public Drink(string name, double value)
    {
        Name = name;
        Value = value;
        
        Validate();
    }
}