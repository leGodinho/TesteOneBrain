using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scaffold.Domain.Aggregations.OrderAggregate;

namespace Scaffold.Infrastructure.Data.Config.DishEFConfiguration;

public class DrinkConfig : IEntityTypeConfiguration<Drink>
{
    public void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder.ToTable(nameof(Drink).Pluralize());
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();
        
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Value).IsRequired();
    }
}