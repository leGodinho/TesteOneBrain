using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scaffold.Domain.Aggregations.UserAggregate.Rules;

namespace Scaffold.Infrastructure.Data.Config.UserEFConfiguration;

public class UserRuleConfig : IEntityTypeConfiguration<UserRule>
{
    public void Configure(EntityTypeBuilder<UserRule> builder)
    {
        builder.ToTable(nameof(UserRule).Pluralize());
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