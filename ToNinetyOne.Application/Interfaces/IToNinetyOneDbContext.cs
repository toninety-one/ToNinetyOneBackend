using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Interfaces;

public interface IToNinetyOneDbContext
{
    DbSet<Discipline> Disciplines { get; set; }
    DbSet<LabWork> LabWorks { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Group> Groups { get; set; }
    DbSet<SubmittedLab> SubmittedLabs { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}