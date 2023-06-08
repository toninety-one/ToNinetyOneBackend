using System.Security.Cryptography;
using MediatR;
using ToNinetyOne.Identity.Interfaces;
using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Refresh;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand, string>
{
    private readonly IToNinetyOneUserDbContext _dbContext;

    public RefreshCommandHandler(IToNinetyOneUserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        var randomNumber = new byte[32];

        using var randomNumberGenerator = RandomNumberGenerator.Create();

        randomNumberGenerator.GetBytes(randomNumber);

        var refreshToken = Convert.ToBase64String(randomNumber);
        var userToken = _dbContext.RefreshTokens.FirstOrDefault(o => o.UserName == request.UserName);

        if (userToken != null)
        {
            userToken.Token = refreshToken;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        else
        {
            var newRefreshToken = new RefreshToken(request.UserName, refreshToken);

            _dbContext.RefreshTokens.Add(newRefreshToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        return refreshToken;
    }
}