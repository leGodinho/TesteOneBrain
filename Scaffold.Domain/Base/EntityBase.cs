using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Scaffold.Domain.Base;

public abstract class EntityBase<T,TValidator> : IEntityBase, IValidableEntity<TValidator>
    where TValidator : AbstractValidator<T>
    where T : class
{
    
    public int Id { get; protected set; }
    public TValidator Validator => Activator.CreateInstance<TValidator>();
    public ValidationResult ValidationResult => Validator.Validate(this as T);
    public bool IsValid => ValidationResult.IsValid;
    
    public void Validate()
    {
        if (!IsValid)
            throw new InvalidDataException(JsonConvert.SerializeObject(ValidationResult.Errors));
    }
}