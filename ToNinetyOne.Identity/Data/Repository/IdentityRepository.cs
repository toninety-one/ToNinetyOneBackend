using System.Security.Cryptography;
using ToNinetyOne.Identity.Data.Interface;
using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.Identity.Data.Repository;

public class IdentityRepository : IIdentity
{
    private readonly IToNinetyOneUserDbContext _context;

    public IdentityRepository(IToNinetyOneUserDbContext dbContext)
    {
        _context = dbContext;
    }

    public string GenerateRefreshToken(string username)
    {
        var randomNumber = new byte[32];
        
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        
        randomNumberGenerator.GetBytes(randomNumber);
        
        var refreshToken = Convert.ToBase64String(randomNumber);
        var user = _context.RefreshTokens.FirstOrDefault(o => o.UserName == username);
            
        if (user != null)
        {
            user.Token = refreshToken;
            _context.SaveChanges();
        }
        else
        {
            var newRefreshToken = new RefreshToken(username, refreshToken);

            _context.RefreshTokens.Add(newRefreshToken);
            
            _context.SaveChanges();
        }

        return refreshToken;
    }
}