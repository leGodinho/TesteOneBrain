using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scaffold.Domain.Aggregations.UserAggregate;
using Scaffold.Domain.Aggregations.UserAggregate.ValueObjects.Login;

namespace Scaffold.Infrastructure.Data.Config.UserEFConfiguration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User).Pluralize());
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();

        builder.Property(c => c.CreatedAt).HasDefaultValue(DateTimeOffset.UtcNow).IsRequired();
        builder.Property(c => c.CreatedBy);

        builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        builder.Property(c => c.DeletedAt).HasDefaultValue(null);
        builder.Property(c => c.DeletedBy).HasDefaultValue(null);
        
        builder.ComplexProperty(o => o.Login, a =>
        {
            a.Property(c => c.Username).HasColumnName(nameof(Login.Username)).HasMaxLength(100).IsRequired();
            a.Property(c => c.Password).HasColumnName(nameof(Login.Password)).HasMaxLength(100).IsRequired();
            a.Property(c => c.LoginAttempts).HasColumnName(nameof(Login.LoginAttempts)).HasDefaultValue(0).IsRequired();
            a.Property(c => c.Blocked).HasColumnName(nameof(Login.Blocked)).HasDefaultValue(false).IsRequired();
        });
        
        builder.HasOne(c => c.Person)
            .WithMany()
            .HasForeignKey(c => c.PersonId);

        builder.Navigation(e => e.Person).AutoInclude();
        builder.Navigation(e => e.Roles).AutoInclude();
    }
}