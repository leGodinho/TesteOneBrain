namespace Scaffold.Domain.Base;

public interface IDeletableEntity
{    
    bool IsDeleted { get; }
    int? DeletedBy  { get; }
    DateTimeOffset? DeletedAt { get; }
}