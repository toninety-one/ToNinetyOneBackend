using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Persistence.EntityTypeConfigurations;

public class LabWorkConfiguration : IEntityTypeConfiguration<LabWork>
{
    public void Configure(EntityTypeBuilder<LabWork> builder)
    {
        builder.HasKey(labWork => labWork.Id);
        builder.HasIndex(labWork => labWork.Id).IsUnique();
        builder.Property(labWork => labWork.Title).IsRequired();
    }
}