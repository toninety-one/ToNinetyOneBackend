using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.UpdateDiscipline;

public class UpdateDisciplineCommandHandler : IRequestHandler<UpdateDisciplineCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public UpdateDisciplineCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateDisciplineCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Disciplines.FirstOrDefaultAsync(discipline => discipline.Id == request.Id,
                cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
            throw new NotFoundException(nameof(Domain.LabWork), request.Id);

        entity.Title = request.Title;
        entity.EditDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}