using FluentValidation;

namespace Scaffold.Domain.Base;

public class CreatableEntityBase<T, TValidator> : EntityBase<T, TValidator>, ICreatableEntity
    where T : class
    where TValidator : AbstractValidator<T>
{
    public DateTimeOffset? CreatedAt { get; protected set; }
    public int? CreatedBy  { get; protected set; }
}