using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Persistence.EntityTypeConfigurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(o => o.Id);
        builder
            .HasMany(o => o.Users)
            .WithOne(o => o.UserGroup);
        builder
            .HasMany(g => g.Disciplines)
            .WithMany(d => d.Groups);
    }
}