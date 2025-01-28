using Scaffold.Domain.Aggregations.UserAggregate;
using Scaffold.Domain.Dtos.Users.Create;
using Scaffold.Domain.Dtos.Users.Delete;
using Scaffold.Domain.Dtos.Users.Get;
using Scaffold.Domain.Dtos.Users.List;
using Scaffold.Domain.Dtos.Users.Update;
using Scaffold.Domain.Interfaces.Repositories;
using Scaffold.Domain.Interfaces.Services;

namespace Scaffold.Application.Services.Users;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<CreateUserResponse> Create(CreateUserRequest request)
    {
        var newUser = new User(
            request.Name, 
            request.Document, 
            request.UserName, 
            request.Password);
        
        var result = await userRepository.Add(newUser);

        return new CreateUserResponse(result.Id, result.Person.Name);
    }
    
    public async Task<UpdateUserResponse> Update(UpdateUserRequest request)
    {
        var currentUser = await userRepository.Get(request.Id);

        if (currentUser is null)
            throw new InvalidDataException("Registro não encontrado");
            
        currentUser.Update(request.Document, request.Name);

        var result = await userRepository.Update(currentUser);

        return new UpdateUserResponse(
            result.Id, 
            result.Person.Name, 
            result.Person.Document.Formatted());
    }
    
    public async Task<DeleteUserResponse> Delete(int userId)
    {
        var result = await userRepository.Delete(userId);
        return new DeleteUserResponse(result);
    }

    public Task<ListUserResponse> List(string name)
    {
        var result = userRepository.List(name);
        return result;
    }

    public async Task<GetUserResponse> Get(int id)
    {
        var result = await userRepository.Get(id);
        return new GetUserResponse(result.Id, result.Person.Name, result.Login.Username, result.Person.Document.Formatted());
    }
}