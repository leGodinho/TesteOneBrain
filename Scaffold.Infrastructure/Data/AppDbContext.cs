using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Infrastructure.Data;

public class AppDbContext  : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // dotnet ef migrations add Initial --verbose --project Scaffold.Infrastructure --startup-project Scaffold.Web
        // dotnet ef database update --verbose --project Scaffold.Infrastructure --startup-project Scaffold.Web
        // dotnet ef migrations remove --verbose --project Scaffold.Infrastructure --startup-project Scaffold.Web
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        return result;
    }

    public override int SaveChanges() => SaveChangesAsync().GetAwaiter().GetResult();
}