using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;
using ToNinetyOne.Persistence.EntityTypeConfigurations;

namespace ToNinetyOne.Persistence;

public class ToNinetyOneDbContext : DbContext, IToNinetyOneDbContext
{
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<LabWork> LabWorks { get; set; }
    public DbSet<User> Users { get; set; }

    public ToNinetyOneDbContext(DbContextOptions<ToNinetyOneDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new LabWorkConfiguration());
        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}