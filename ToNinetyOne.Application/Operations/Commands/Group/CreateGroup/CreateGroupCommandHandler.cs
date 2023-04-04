using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;
        
namespace ToNinetyOne.Application.Operations.Commands.Group.CreateGroup;
        
public class  CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;
        
    public CreateGroupCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
