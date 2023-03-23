using Microsoft.EntityFrameworkCore;
using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.Identity.Data.Interface;

public interface IToNinetyOneUserDbContext
{
    DbSet<RefreshToken> RefreshTokens { get; set; }
    DbSet<User> Users { get; set; }
    int SaveChanges();
}