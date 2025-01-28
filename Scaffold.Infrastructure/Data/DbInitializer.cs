using Microsoft.EntityFrameworkCore;
using Scaffold.Domain.Aggregations.OrderAggregate;
using Scaffold.Domain.Aggregations.UserAggregate;
using Scaffold.Domain.Aggregations.UserAggregate.Persons;

namespace Scaffold.Infrastructure.Data;

public class DbInitializer(AppDbContext appDbContext) 
    : IDbInitializer
{
    public void Seed()
    {
        SeedPeople();
    }

    private void SeedPeople()
    {
        if(appDbContext.Set<Person>().Any())
            return;

        //appDbContext.People.Add(new Person("Master User", "0000001"));
        //appDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        
        appDbContext.Set<User>().Add(new User("Master User", "0000001", "master", "Senha@123"));
        appDbContext.SaveChangesAsync().GetAwaiter().GetResult();

        appDbContext.Set<Dish>().Add(new Dish("X-Simples", 5.80d));
        appDbContext.Set<Dish>().Add(new Dish("X-Salada", 8.10d));
        appDbContext.Set<Dish>().Add(new Dish("X-Frango", 9.0d));
        appDbContext.Set<Dish>().Add(new Dish("X-Alcatra", 12.0d));
        appDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        
        appDbContext.Set<Drink>().Add(new Drink("Água sem gás", 2.0d));
        appDbContext.Set<Drink>().Add(new Drink("Água com gás", 3.5d));
        appDbContext.Set<Drink>().Add(new Drink("Refrigerante Lata", 5.5d));
        appDbContext.Set<Drink>().Add(new Drink("Refrigerante 600ml", 8.90d));
        appDbContext.Set<Drink>().Add(new Drink("Refrigerante 2l", 14.4d));
        appDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        
        appDbContext.Set<Table>().Add(new Table(1, 2));
        appDbContext.Set<Table>().Add(new Table(2, 2));
        appDbContext.Set<Table>().Add(new Table(3, 4));
        appDbContext.Set<Table>().Add(new Table(4, 4));
        appDbContext.Set<Table>().Add(new Table(5, 6));
        appDbContext.Set<Table>().Add(new Table(6, 6));
        appDbContext.SaveChangesAsync().GetAwaiter().GetResult();
        
        appDbContext.Set<Client>().Add(new Client("Cliente teste", "12345678"));
        appDbContext.SaveChangesAsync().GetAwaiter().GetResult();

        var existingTable = appDbContext.Set<Table>().FirstOrDefaultAsync().GetAwaiter().GetResult();
        var existingClient = appDbContext.Set<Client>().FirstOrDefaultAsync().GetAwaiter().GetResult();
        var existingDish = appDbContext.Set<Dish>().FirstOrDefaultAsync().GetAwaiter().GetResult();
        var existingDrink = appDbContext.Set<Drink>().FirstOrDefaultAsync().GetAwaiter().GetResult();

        var newOrder = new Order(existingTable);
        newOrder.HaveClient(existingClient);
        newOrder.OrderDish(existingDish);
        newOrder.OrderDrink(existingDrink);

        appDbContext.Set<Order>().Add(newOrder);
        appDbContext.SaveChangesAsync().GetAwaiter().GetResult();
    }
}