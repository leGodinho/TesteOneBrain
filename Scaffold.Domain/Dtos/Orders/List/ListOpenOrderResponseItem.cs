namespace Scaffold.Domain.Dtos.Orders.List;

public record ListOpenOrderResponseItem(int OrderId, DateTime DateOpen, double CurrentValue);