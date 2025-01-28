using FluentValidation;

namespace Scaffold.Domain.Base;

public class CreatableAndDeletableEntityBase<T, TValidator> : EntityBase<T, TValidator>, IDeletableEntity, ICreatableEntity
    where T : class
    where TValidator : AbstractValidator<T>
{
    public bool IsDeleted { get; }
    public int? DeletedBy { get; }
    public DateTimeOffset? DeletedAt { get; }
    public DateTimeOffset? CreatedAt { get; }
    public int? CreatedBy { get; }
}