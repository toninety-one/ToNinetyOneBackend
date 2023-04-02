using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.IdentityPersistence.EntityTypeConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.HasIndex(user => user.Id).IsUnique();
        builder.Property(user => user.UserName).IsRequired();
        builder.Property(user => user.Password).IsRequired();
        builder.Property(user => user.Salt).IsRequired();
        builder.Property(user => user.GroupId).IsRequired();
    }
}