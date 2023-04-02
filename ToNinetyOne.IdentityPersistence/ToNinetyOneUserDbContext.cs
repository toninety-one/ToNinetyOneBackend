using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Identity.Interfaces;
using ToNinetyOne.IdentityDomain;
using ToNinetyOne.IdentityPersistence.EntityTypeConfigurations;

namespace ToNinetyOne.IdentityPersistence;

public class ToNinetyOneUserDbContext : DbContext, IToNinetyOneUserDbContext
{
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

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