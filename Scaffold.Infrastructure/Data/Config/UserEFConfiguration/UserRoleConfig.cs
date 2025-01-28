using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scaffold.Domain.Aggregations.UserAggregate.Roles;

namespace Scaffold.Infrastructure.Data.Config.UserEFConfiguration;

public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(nameof(UserRole).Pluralize());
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(c => c.CreatedAt).HasDefaultValue(DateTimeOffset.UtcNow).IsRequired();
        builder.Property(c => c.CreatedBy).IsRequired();

        builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        builder.Property(c => c.DeletedAt).HasDefaultValue(null);
        builder.Property(c => c.DeletedBy).HasDefaultValue(null);
        
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(500).IsRequired();
    }
}