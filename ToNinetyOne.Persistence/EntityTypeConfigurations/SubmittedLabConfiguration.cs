using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Persistence.EntityTypeConfigurations;

public class SubmittedLabConfiguration : IEntityTypeConfiguration<SubmittedLab>
{
    public void Configure(EntityTypeBuilder<SubmittedLab> builder)
    {
        builder.HasKey(labWork => labWork.Id);
        builder.HasIndex(labWork => labWork.Id).IsUnique();
        builder.Property(labWork => labWork.Title).IsRequired();

        builder
            .HasOne(l => l.SelfLabWork)
            .WithMany(l => l.SubmittedLabs);
        builder.HasOne(l => l.SelfUser);
    }
}