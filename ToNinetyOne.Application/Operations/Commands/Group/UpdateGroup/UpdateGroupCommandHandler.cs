using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;
        
namespace ToNinetyOne.Application.Operations.Commands.Group.UpdateGroup;
        
public class  UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;
        
    public UpdateGroupCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task<Guid> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
