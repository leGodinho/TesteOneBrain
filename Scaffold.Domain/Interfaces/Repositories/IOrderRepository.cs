using Scaffold.Domain.Aggregations.OrderAggregate;
using Scaffold.Domain.Dtos.Orders.List;

namespace Scaffold.Domain.Interfaces.Repositories;

public interface IOrderRepository
{
    Task<Order> Add(Order newOrder);
    Task<IEnumerable<ListOpenOrderResponseItem>> ListOpenOrder();
}