using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;
using ToNinetyOne.Persistence.EntityTypeConfigurations;

namespace ToNinetyOne.Persistence;

public sealed class ToNinetyOneDbContext : DbContext, IToNinetyOneDbContext
{
    public DbSet<Discipline> Disciplines { get; set; } = null!;
    public DbSet<LabWork> LabWorks { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<SubmittedLab> SubmittedLabs { get; set; } = null!;

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
        modelBuilder.ApplyConfiguration(new SubmittedLabConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}