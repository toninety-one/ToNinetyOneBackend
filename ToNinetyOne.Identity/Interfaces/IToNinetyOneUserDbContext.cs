using Microsoft.EntityFrameworkCore;
using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.Identity.Interfaces;

public interface IToNinetyOneUserDbContext
{
    DbSet<RefreshToken> RefreshTokens { get; set; }
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}