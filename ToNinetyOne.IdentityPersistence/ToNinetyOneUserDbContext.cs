using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Identity.Interfaces;
using ToNinetyOne.IdentityDomain;
using ToNinetyOne.IdentityPersistence.EntityTypeConfigurations;

namespace ToNinetyOne.IdentityPersistence;

public class ToNinetyOneUserDbContext : DbContext, IToNinetyOneUserDbContext
{
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public ToNinetyOneUserDbContext(DbContextOptions<ToNinetyOneUserDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}