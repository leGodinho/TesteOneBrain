using Scaffold.Domain.Dtos.Tables.Details;
using Scaffold.Domain.Interfaces.Repositories;
using Scaffold.Domain.Interfaces.Services;

namespace Scaffold.Application.Services.Tables;

public class TableService(ITableRepository tableRepository) : ITableService
{
    public async Task<TableDetailsResponse> GetDetails(int tableId)
    {
        var result = await tableRepository.GetDetails(tableId);
        return result;
    }
}