using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Persistence.EntityTypeConfigurations;

public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.HasKey(discipline => discipline.Id);
        builder.HasIndex(discipline => discipline.Id).IsUnique();
        builder.Property(discipline => discipline.Title).IsRequired();
    }
}