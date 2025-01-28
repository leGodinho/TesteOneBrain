using Scaffold.Domain.Dtos.Users.Create;
using Scaffold.Domain.Dtos.Users.Delete;
using Scaffold.Domain.Dtos.Users.Get;
using Scaffold.Domain.Dtos.Users.List;
using Scaffold.Domain.Dtos.Users.Update;

namespace Scaffold.Domain.Interfaces.Services;

public interface IUserService
{
    Task<CreateUserResponse> Create(CreateUserRequest request);
    Task<UpdateUserResponse> Update(UpdateUserRequest request);
    Task<DeleteUserResponse> Delete(int userId);
    Task<ListUserResponse> List(string name);
    Task<GetUserResponse> Get(int id);
}