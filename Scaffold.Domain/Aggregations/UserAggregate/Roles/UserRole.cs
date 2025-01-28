using System.Collections.ObjectModel;
using Scaffold.Domain.Aggregations.UserAggregate.Rules;
using Scaffold.Domain.Base;
using Scaffold.Domain.Validators.Users;

namespace Scaffold.Domain.Aggregations.UserAggregate.Roles;

public class UserRole : CreatableAndDeletableEntityBase<UserRole, UserRoleValidator>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    private List<UserRule> _rules = new();
    
    public virtual ReadOnlyCollection<UserRule> Rules => _rules.AsReadOnly();

    public void AddRule(UserRule userRule)
    {
        if(_rules.All(c => c != userRule))
            _rules.Add(userRule);   
    }
}
