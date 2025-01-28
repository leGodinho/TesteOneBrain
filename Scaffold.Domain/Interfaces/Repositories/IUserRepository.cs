using Scaffold.Domain.Aggregations.UserAggregate;
using Scaffold.Domain.Dtos.Users.Get;
using Scaffold.Domain.Dtos.Users.List;

namespace Scaffold.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> Get(int id);
    Task<User> Update(User currentUser);
    Task<User> Add(User newUser);
    Task<bool> Delete(int userId);
    Task<User?> GetByUsername(string userName);
    Task<ListUserResponse> List(string name);
}