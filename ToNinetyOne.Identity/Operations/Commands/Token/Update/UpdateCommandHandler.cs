using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Identity.Interfaces;
using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Update;

public class UpdateCommandHandler : IRequestHandler<UpdateCommand, string>
{
    private readonly IToNinetyOneUserDbContext _dbContext;

    public UpdateCommandHandler(IToNinetyOneUserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _dbContext.RefreshTokens.FirstOrDefaultAsync(token =>
            token.UserName == request.UserName && token.Token == request.RefreshToken, cancellationToken);

        if (refreshToken == null) throw new NotAuthorizedException(NotAuthorizedException.InvalidAuthData);

        return refreshToken.Token;
    }
}