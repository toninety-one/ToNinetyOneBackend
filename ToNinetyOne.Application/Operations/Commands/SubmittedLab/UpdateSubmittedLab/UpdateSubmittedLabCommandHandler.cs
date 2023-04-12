using MediatR;
using ToNinetyOne.Application.Interfaces;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.UpdateSubmittedLab;

public class UpdateSubmittedLabCommandHandler : IRequestHandler<UpdateSubmittedLabCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public UpdateSubmittedLabCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(UpdateSubmittedLabCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}