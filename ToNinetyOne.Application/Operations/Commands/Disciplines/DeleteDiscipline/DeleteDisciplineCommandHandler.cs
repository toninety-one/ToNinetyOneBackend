using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Common.Exceptions;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Commands.Disciplines.DeleteDiscipline;

public class DeleteDisciplineCommandHandler : IRequestHandler<DeleteDisciplineCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public DeleteDisciplineCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteDisciplineCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Disciplines.FirstOrDefaultAsync(discipline => discipline.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundException(nameof(LabWork), request.Id);
        }

        _dbContext.Disciplines.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}