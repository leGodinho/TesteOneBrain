using Microsoft.EntityFrameworkCore;
using Scaffold.Domain.Aggregations.UserAggregate;
using Scaffold.Domain.Dtos.Users.List;
using Scaffold.Domain.Interfaces.Repositories;
using Scaffold.Infrastructure.Data;

namespace Scaffold.Infrastructure.Repositories;

public class UserRepository(AppDbContext appDbContext) : IUserRepository
{
    public async Task<User?> Get(int id)
    {
        var result = await appDbContext.Set<User>().Where(c => !c.IsDeleted
                                                               && c.Id == id)
            .SingleOrDefaultAsync();

        return result;
    }

    public async Task<User> Update(User currentUser)
    {
        var result = appDbContext.Set<User>().Update(currentUser);
        await appDbContext.SaveChangesAsync();
        return await Task.FromResult(result.Entity);
    }

    public async Task<User> Add(User newUser)
    {
        var result = await appDbContext.Set<User>().AddAsync(newUser);
        await appDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> Delete(int userId)
    {
        var currentUser = await appDbContext.Set<User>().FirstAsync(c => c.Id == userId);
        appDbContext.Remove(currentUser);
        await appDbContext.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    public async Task<User?> GetByUsername(string userName)
    {
        var result = await
            appDbContext.Set<User>()
                .Where(c => !c.IsDeleted && c.Login.Username == userName)
                .SingleOrDefaultAsync();

        return result;
    }

    public async Task<ListUserResponse> List(string name)
    {
        var result = await
            appDbContext.Set<User>()
                .Where(c => name == string.Empty || c.Person.Name == name)
                .Select(c => new ListUserResponseItem(c.Id, c.Person.Name))
                .ToListAsync();

        return new ListUserResponse(result);
    }
}