using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scaffold.Domain.Aggregations.UserAggregate.Persons;

namespace Scaffold.Infrastructure.Data.Config.UserEFConfiguration;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable(nameof(Person).Pluralize());
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.CreatedAt).HasDefaultValue(DateTimeOffset.UtcNow).IsRequired();
        builder.Property(c => c.CreatedBy);

        builder.Property(c => c.IsDeleted).HasDefaultValue(false);
        builder.Property(c => c.DeletedAt).HasDefaultValue(null);
        builder.Property(c => c.DeletedBy).HasDefaultValue(null);
        builder.ComplexProperty(o => o.Document, a =>
        {
            a.Property(p => p.RawNumber).HasColumnName(nameof(Person.Document));
        });

        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(c => c.CreatedBy);
        
        builder.HasOne<Person>()
            .WithMany()
            .HasForeignKey(c => c.DeletedBy);
    }
}

