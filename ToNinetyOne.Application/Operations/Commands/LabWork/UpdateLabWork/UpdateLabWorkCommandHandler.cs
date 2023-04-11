using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.UpdateLabWork;

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

        if (entity == null)
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