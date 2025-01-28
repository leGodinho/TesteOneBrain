using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scaffold.Domain.Aggregations.OrderAggregate;

namespace Scaffold.Infrastructure.Data.Config.OrderEFConfiguration;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(nameof(Order).Pluralize());
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();

        builder.HasMany(c => c.Dishes)
            .WithMany();
        
        builder.HasMany(c => c.Drinks)
            .WithMany();
    }
}