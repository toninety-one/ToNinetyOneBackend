using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;
        
namespace ToNinetyOne.Application.Operations.Commands.Group.DeleteGroup;
        
public class  DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;
        
    public DeleteGroupCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task<Guid> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
