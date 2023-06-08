using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;
using ToNinetyOne.Persistence.EntityTypeConfigurations;
using File = ToNinetyOne.Domain.File;

namespace ToNinetyOne.Persistence;

public sealed class ToNinetyOneDbContext : DbContext, IToNinetyOneDbContext
{
    public ToNinetyOneDbContext(DbContextOptions<ToNinetyOneDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Discipline> Disciplines { get; set; } = null!;
    public DbSet<LabWork> LabWorks { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Group> Groups { get; set; } = null!;
    public DbSet<SubmittedLab> SubmittedLabs { get; set; } = null!;
    public DbSet<File> Files { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new LabWorkConfiguration());
        modelBuilder.ApplyConfiguration(new GroupConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new SubmittedLabConfiguration());
        modelBuilder.ApplyConfiguration(new FileConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}