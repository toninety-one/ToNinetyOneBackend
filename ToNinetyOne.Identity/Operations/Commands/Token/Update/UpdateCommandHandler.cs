using System.Security.Cryptography;
using MediatR;
using ToNinetyOne.Identity.Interfaces;

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
        var refreshToken = _dbContext.RefreshTokens.FirstOrDefault(token =>
            token.UserName == request.UserName && token.Token == request.RefreshToken);

        if (refreshToken == null)
        {
            return null;
        }
        
        return refreshToken.Token;
    }
}