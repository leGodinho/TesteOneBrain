using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scaffold.Domain.Aggregations.OrderAggregate;

namespace Scaffold.Infrastructure.Data.Config.OrderEFConfiguration;

public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable(nameof(Client).Pluralize());
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();
        
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.PhoneNumber).HasMaxLength(20).IsRequired();
    }
}