using FluentValidation;
using Scaffold.Domain.Aggregations.OrderAggregate;

namespace Scaffold.Domain.Validators.Orders;

public class ClientValidator : AbstractValidator<Client>
{
     public ClientValidator()
     {
          RuleFor(c => c.Id).NotNull();
          RuleFor(c => c.Name).NotNull().NotEmpty().Length(5, 100);
          RuleFor(c => c.PhoneNumber).NotNull();
     }
}