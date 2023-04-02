using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Commands.LabWorks.UpdateLabWork;

public class UpdateLabWorkCommandHandler : IRequestHandler<UpdateLabWorkCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public UpdateLabWorkCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateLabWorkCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.LabWorks.FirstOrDefaultAsync(labWork => labWork.Id == request.Id, cancellationToken);

        if (entity == null || entity.DisciplineId != request.DisciplineId)
        {
            throw new NotFoundException(nameof(LabWork), request.Id);
        }

        entity.Title = request.Title;
        entity.Details = request.Details;
        entity.FilePath = request.FilePath;
        entity.EditDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}