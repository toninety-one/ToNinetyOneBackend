using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Identity.Data.Interface;
using ToNinetyOne.IdentityDomain;
using ToNinetyOne.UserPersistence.EntityTypeConfigurations;

namespace ToNinetyOne.UserPersistence;

public class ToNinetyOneUserDbContext : DbContext, IToNinetyOneUserDbContext
{
    public ToNinetyOneUserDbContext(DbContextOptions<ToNinetyOneUserDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}