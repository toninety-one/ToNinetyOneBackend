using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Commands.LabWorks.CreateLabWork;

public class CreateLabWorkCommandHandler : IRequestHandler<CreateLabWorkCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public CreateLabWorkCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Handle(CreateLabWorkCommand request, CancellationToken cancellationToken)
    {
        var labWork = new LabWork
        {
            DisciplineId = request.DisciplineId,
            Title = request.Title,
            Details = request.Details,
            Id = Guid.NewGuid(),
            FilePath = request.FilePath,
        };

        await _dbContext.LabWorks.AddAsync(labWork, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return labWork.Id;
    }
}