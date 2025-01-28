using Microsoft.EntityFrameworkCore;
using Scaffold.Domain.Aggregations.OrderAggregate;
using Scaffold.Domain.Dtos.Tables.Details;
using Scaffold.Domain.Interfaces.Repositories;
using Scaffold.Infrastructure.Data;

namespace Scaffold.Infrastructure.Repositories;

public class TableRepository(AppDbContext appDbContext) : ITableRepository
{
    public async Task<Table?> GetTableByNumber(int tableNumber)
    {
        var result = await appDbContext.Set<Table>().FirstOrDefaultAsync(c => c.Number == tableNumber);
        return result;
    }

    public async Task<TableDetailsResponse> GetDetails(int tableId)
    {
        var result = await appDbContext.Set<Table>().FirstOrDefaultAsync(c => c.Id == tableId);
        var tableOrders = await appDbContext.Set<Order>()
            .Include(c => c.Table).Include(c => c.Dishes)
            .Include(c => c.Table).Include(c => c.Drinks)
            .Where(c => c.Table.Id == tableId)
            .ToListAsync();

        return new TableDetailsResponse(
            result.Number, 
            result.PeopleAmount, 
            tableOrders, 
            tableOrders.Sum(o => o.Drinks.Sum(d => d.Value)) 
                         + tableOrders.Sum(o => o.Dishes.Sum(d => d.Value)));
    }
}