using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Identity.Interfaces;
using ToNinetyOne.IdentityDomain;
using ToNinetyOne.IdentityDomain.Static;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Authenticate;

public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthenticateResult>
{
    private readonly IToNinetyOneUserDbContext _dbContext;

    public AuthenticateCommandHandler(IToNinetyOneUserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AuthenticateResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(
            u => u.UserName == request.UserName && u.Password == request.Password, cancellationToken);

        if (user == null)
        {
            throw new NotAuthorizedException(nameof(User), request.UserName);
        }

        return new AuthenticateResult()
        {
            Id = user.Id,
            Role = user.Role,
            UserName = user.UserName,
        };
    }
}