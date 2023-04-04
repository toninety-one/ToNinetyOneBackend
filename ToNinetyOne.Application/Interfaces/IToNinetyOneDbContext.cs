using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Domain;
using Group = System.Text.RegularExpressions.Group;

namespace ToNinetyOne.Application.Interfaces;

public interface IToNinetyOneDbContext
{
    DbSet<Discipline> Disciplines { get; set; }
    DbSet<LabWork> LabWorks { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<Domain.Group> Groups { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}