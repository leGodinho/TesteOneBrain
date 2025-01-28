using Scaffold.Domain.Base;
using Scaffold.Domain.Validators.Orders;

namespace Scaffold.Domain.Aggregations.OrderAggregate;

public class Dish : EntityBase<Dish, DishValidator>
{
    public string Name { get; private set; } = string.Empty;
    public double Value { get; private set; }

    public Dish(string name, double value)
    {
        Name = name;
        Value = value;
        
        Validate();
    }
}