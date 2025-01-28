namespace Scaffold.Domain.Dtos.Orders.Create;

public record CreateOrderRequest(
    string ClientName, 
    string ClientPhoneNumber, 
    int TableNumber,
    int PeopleAmount);