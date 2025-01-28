namespace Scaffold.Domain.Base;

public interface ICreatableEntity
{
    DateTimeOffset? CreatedAt { get; }
    int? CreatedBy  { get; }
}