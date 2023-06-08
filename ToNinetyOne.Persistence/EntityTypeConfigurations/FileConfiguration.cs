using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Persistence.EntityTypeConfigurations;

public class FileConfiguration : IEntityTypeConfiguration<Domain.File>
{
    public void Configure(EntityTypeBuilder<Domain.File> builder)
    {
        builder.HasKey(f => f.Id);
        builder.HasIndex(f => f.Id).IsUnique();
    }
}