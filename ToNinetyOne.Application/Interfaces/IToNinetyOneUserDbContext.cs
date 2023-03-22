using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Interfaces;

public interface IToNinetyOneUserDbContext
{
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}