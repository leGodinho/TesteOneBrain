using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scaffold.Domain.Aggregations.OrderAggregate;

namespace Scaffold.Infrastructure.Data.Config.OrderEFConfiguration;

public class TableConfig : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.ToTable(nameof(Table).Pluralize());
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();
        
        builder.Property(c => c.Number).IsRequired();
        builder.Property(c => c.PeopleAmount).IsRequired();
    }
}