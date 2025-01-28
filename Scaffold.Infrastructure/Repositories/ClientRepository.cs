using Microsoft.EntityFrameworkCore;
using Scaffold.Domain.Aggregations.OrderAggregate;
using Scaffold.Domain.Interfaces.Repositories;
using Scaffold.Infrastructure.Data;

namespace Scaffold.Infrastructure.Repositories;

public class ClientRepository(AppDbContext appDbContext) : IClientRepository
{
    public async Task<Client?> GetByPhoneNumber(string clientPhoneNumber)
    {
        var result = await appDbContext.Set<Client>().FirstOrDefaultAsync(c => c.PhoneNumber == clientPhoneNumber);
        return result;
    }
}