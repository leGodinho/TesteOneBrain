using System.Collections.ObjectModel;
using Scaffold.Domain.Aggregations.UserAggregate.Roles;
using Scaffold.Domain.Base;
using Scaffold.Domain.Validators.Users;

namespace Scaffold.Domain.Aggregations.UserAggregate.Rules;

public class UserRule : CreatableAndDeletableEntityBase<UserRule, UserRuleValidator>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Icon { get; private set; }
    
    private List<UserRole> _roles = new();
    
    public virtual ReadOnlyCollection<UserRole> Roles => _roles.AsReadOnly();
}