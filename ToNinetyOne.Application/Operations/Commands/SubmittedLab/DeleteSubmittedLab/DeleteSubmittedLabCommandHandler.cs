using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;
        
namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.DeleteSubmittedLab;
        
public class  DeleteSubmittedLabCommandHandler : IRequestHandler<DeleteSubmittedLabCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;
        
    public DeleteSubmittedLabCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task<Guid> Handle(DeleteSubmittedLabCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
