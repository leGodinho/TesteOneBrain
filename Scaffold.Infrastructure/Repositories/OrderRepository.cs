using Microsoft.EntityFrameworkCore;
using Scaffold.Domain.Aggregations.OrderAggregate;
using Scaffold.Domain.Dtos.Orders.List;
using Scaffold.Domain.Interfaces.Repositories;
using Scaffold.Infrastructure.Data;

namespace Scaffold.Infrastructure.Repositories;

public class OrderRepository(AppDbContext appDbContext) : IOrderRepository 
{
    public async Task<Order> Add(Order newOrder)
    {
        var result = await appDbContext.AddAsync(newOrder);
        await appDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<IEnumerable<ListOpenOrderResponseItem>> ListOpenOrder()
    {
        var result = await 
            appDbContext.Set<Order>()
                .Include(c => c.Dishes)
                .Include(c => c.Drinks)
                .Where(c => c.Close == null)
                .Select(c =>
                    new ListOpenOrderResponseItem(c.Id, c.Open,
                        c.Dishes.Sum(t => t.Value) + c.Drinks.Sum(t => t.Value)))
                .ToListAsync();
        
        return result;
    }
}