using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Identity.Interfaces;
using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.Identity.Operations.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IToNinetyOneUserDbContext _dbContext;

    public UpdateUserCommandHandler(IToNinetyOneUserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(User), request.UserId);

        entity.UserName = request.UserName;

        if (user.Role == Roles.Administrator)
        {
            entity.Role = request.UserRole;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}