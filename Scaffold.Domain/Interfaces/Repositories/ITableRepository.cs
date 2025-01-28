using Scaffold.Domain.Aggregations.OrderAggregate;
using Scaffold.Domain.Dtos.Tables.Details;

namespace Scaffold.Domain.Interfaces.Repositories;

public interface ITableRepository
{
    Task<Table?> GetTableByNumber(int tableNumber);
    Task<TableDetailsResponse> GetDetails(int tableId);
}