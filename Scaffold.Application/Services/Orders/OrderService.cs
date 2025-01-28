using Scaffold.Domain.Aggregations.OrderAggregate;
using Scaffold.Domain.Dtos.Orders.Create;
using Scaffold.Domain.Dtos.Orders.List;
using Scaffold.Domain.Interfaces.Repositories;
using Scaffold.Domain.Interfaces.Services;

namespace Scaffold.Application.Services.Orders;

public class OrderService(
    IOrderRepository orderRepository,
    ITableRepository tableRepository,
    IClientRepository clientRepository) : IOrderService
{
    public async Task<CreateOrderResponse> Create(CreateOrderRequest request)
    {
        var existingTable = await tableRepository.GetTableByNumber(request.TableNumber);
        var existingClient = await clientRepository.GetByPhoneNumber(request.ClientPhoneNumber);

        if (existingTable is null)
            throw new InvalidDataException("Nenhuma mesa foi encontrada com o número informado");

        var newOrder = new Order(existingTable);

        if (existingClient is null)
            newOrder.HaveClient(request.ClientName, request.ClientPhoneNumber);
        else
            newOrder.HaveClient(existingClient);

        var result = await orderRepository.Add(newOrder);

        return new CreateOrderResponse(result.Id);
    }

    public async Task<ListOpenOrderResponse> ListOpenOrder()
    {
        var result = await orderRepository.ListOpenOrder();
        return new ListOpenOrderResponse(result);
    }
}