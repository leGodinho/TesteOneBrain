using FluentValidation;
using Scaffold.Domain.Aggregations.OrderAggregate;

namespace Scaffold.Domain.Validators.Orders;

public class TableValidator  : AbstractValidator<Table>
{
    public TableValidator()
    {
        RuleFor(c => c.Id).NotNull();
        RuleFor(c => c.Number).NotNull();
        RuleFor(c => c.PeopleAmount).NotNull();
    }
}