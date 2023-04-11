using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Commands.DisciplineGroup.AddDisciplineGroup;

public class AddDisciplineGroupCommandHandler : IRequestHandler<AddDisciplineGroupCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public AddDisciplineGroupCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(AddDisciplineGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _dbContext.Groups.Include(g => g.Disciplines)
            .FirstOrDefaultAsync(g => g.Id == request.GroupId, cancellationToken);

        var discipline =
            await _dbContext.Disciplines.FirstOrDefaultAsync(d => d.Id == request.DisciplineId, cancellationToken);

        if (group == null)
        {
            throw new NotFoundException(nameof(Domain.Group), request.GroupId);
        }

        if (discipline == null)
        {
            throw new NotFoundException(nameof(Domain.Discipline), request.DisciplineId);
        }

        group.Disciplines.Add(discipline);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return group.Id;
    }
}