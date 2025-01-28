using FluentValidation;
using FluentValidation.Results;

namespace Scaffold.Domain.Base;

public interface IValidableEntity<TValidator>
    where TValidator : IValidator
{
    public TValidator Validator { get;  }
    public ValidationResult ValidationResult { get; }
    public bool IsValid { get; }
}