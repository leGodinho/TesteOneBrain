using FluentValidation;
using Scaffold.Domain.Aggregations.OrderAggregate;

namespace Scaffold.Domain.Validators.Orders;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(c => c.Id).NotNull();
        RuleFor(c => c.Table).NotNull();
        RuleFor(c => c.Client).NotNull();
        RuleFor(c => c.Open).NotNull();
    }
    
}