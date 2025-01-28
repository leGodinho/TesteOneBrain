using Scaffold.Domain.Dtos.Orders.Create;
using Scaffold.Domain.Dtos.Orders.List;

namespace Scaffold.Domain.Interfaces.Services;

public interface IOrderService
{
    Task<CreateOrderResponse> Create(CreateOrderRequest request);
    Task<ListOpenOrderResponse> ListOpenOrder();
}