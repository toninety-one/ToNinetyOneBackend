using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Domain;
        
namespace ToNinetyOne.Application.Operations.Commands.Group.SetUserGroup;
        
public class  SetUserGroupCommandHandler : IRequestHandler<SetUserGroupCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;
        
    public SetUserGroupCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task<Guid> Handle(SetUserGroupCommand request, CancellationToken cancellationToken)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == request.UserId);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }
        
        user.UserGroup = _dbContext.Groups.FirstOrDefault(g => g.Id == request.GroupId);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
