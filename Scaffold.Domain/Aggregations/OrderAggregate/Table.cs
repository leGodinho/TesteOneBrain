using Scaffold.Domain.Base;
using Scaffold.Domain.Validators.Orders;

namespace Scaffold.Domain.Aggregations.OrderAggregate;

public class Table  : EntityBase<Table, TableValidator>
{
    public int Number { get; private set; }
    public int PeopleAmount { get; private set; }

    public Table(int number, int peopleAmount)
    {
        Number = number;
        PeopleAmount = peopleAmount;
        
        Validate();
    }
}