using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.DeleteLabWork;

public class DeleteLabWorkCommandHandler : IRequestHandler<DeleteLabWorkCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public DeleteLabWorkCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteLabWorkCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.LabWorks.FirstOrDefaultAsync(labWork => labWork.Id == request.Id, cancellationToken);

        if (entity == null || entity.SelfDiscipline.Id != request.DisciplineId)
        {
            throw new NotFoundException(nameof(LabWork), request.Id);
        }

        _dbContext.LabWorks.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}