using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;
using ToNinetyOne.Domain.Auth;
using ToNinetyOne.UserPersistence.EntityTypeConfigurations;

namespace ToNinetyOne.UserPersistence;

public class ToNinetyOneUserDbContext : DbContext, IToNinetyOneUserDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    
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