using Scaffold.Domain.Aggregations.OrderAggregate;

namespace Scaffold.Domain.Dtos.Tables.Details;

public record TableDetailsResponse(int number, int peopleAmount, IEnumerable<Order> Orders, double TotalValue);