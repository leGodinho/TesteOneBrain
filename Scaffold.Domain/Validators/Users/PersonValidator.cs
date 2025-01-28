using FluentValidation;
using Scaffold.Domain.Aggregations.UserAggregate.Persons;

namespace Scaffold.Domain.Validators.Users;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(c => c.Id).NotNull();
        RuleFor(c => c.Name).NotNull().NotEmpty().Length(5, 100);
        RuleFor(c => c.Document).NotNull();
    }
}