using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Commands.DisciplineGroup.AddDisciplineGroup;

public class DeleteDisciplineGroupCommandHandler : IRequestHandler<DeleteDisciplineGroupCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public DeleteDisciplineGroupCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteDisciplineGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _dbContext.Groups.Include(g => g.Disciplines)
            .FirstOrDefaultAsync(g => g.Id == request.GroupId, cancellationToken);

        var discipline =
            await _dbContext.Disciplines.FirstOrDefaultAsync(d => d.Id == request.DisciplineId, cancellationToken);

        if (group == null) throw new NotFoundException(nameof(Domain.Group), request.GroupId);

        if (discipline == null) throw new NotFoundException(nameof(Domain.Discipline), request.DisciplineId);

        group.Disciplines?.Remove(discipline);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}