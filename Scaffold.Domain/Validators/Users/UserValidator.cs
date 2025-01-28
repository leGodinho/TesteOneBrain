using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using Scaffold.Domain.Aggregations.UserAggregate;

namespace Scaffold.Domain.Validators.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(c => c.Id).NotNull();
        RuleFor(c => c.Login).NotNull();
        RuleFor(c => c.Person).NotNull();
        RuleFor(c => c.Login.Username).NotNull().Length(5, 20);
    }

    public override ValidationResult Validate(ValidationContext<User> context)
    {
        var validation = base.Validate(context);
        if (!validation.IsValid)
            throw new InvalidDataException(JsonConvert.SerializeObject(validation.Errors));

        return validation;
    }
}