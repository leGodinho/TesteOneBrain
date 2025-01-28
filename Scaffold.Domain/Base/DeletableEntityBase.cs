using FluentValidation;

namespace Scaffold.Domain.Base;

public abstract class DeletableEntityBase<T, TValidator> : EntityBase<T, TValidator>, IDeletableEntity
    where T : class
    where TValidator : AbstractValidator<T>
{
    public bool IsDeleted { get; protected set; }
    public int? DeletedBy  { get; protected set; }
    public DateTimeOffset? DeletedAt { get; protected set; }
}