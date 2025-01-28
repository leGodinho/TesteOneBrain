namespace Scaffold.Domain.Dtos.Orders.List;

public record ListOpenOrderResponse(IEnumerable<ListOpenOrderResponseItem> OpenOrders);