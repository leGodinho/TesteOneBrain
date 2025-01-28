using Scaffold.Domain.Aggregations.OrderAggregate;

namespace Scaffold.Domain.Interfaces.Repositories;

public interface IClientRepository
{
    Task<Client?> GetByPhoneNumber(string clientPhoneNumber);
}