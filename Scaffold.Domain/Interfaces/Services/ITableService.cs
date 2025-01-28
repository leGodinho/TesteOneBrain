using Scaffold.Domain.Dtos.Tables.Details;

namespace Scaffold.Domain.Interfaces.Services;

public interface ITableService
{
    Task<TableDetailsResponse> GetDetails(int tableId);
}