using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
        
namespace ToNinetyOne.Application.Operations.Commands.User.UpdateUser;
        
public class  UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;
        
    public UpdateUserCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
    
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);
        
        throw new NotImplementedException();
    }
}
