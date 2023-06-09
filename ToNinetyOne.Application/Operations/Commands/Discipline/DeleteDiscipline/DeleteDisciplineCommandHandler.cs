using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.DeleteDiscipline;

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
            await _dbContext.Disciplines.FirstOrDefaultAsync(
                discipline => discipline.Id == request.Id &&
                              (discipline.UserId == request.UserId || request.UserRole == Roles.Administrator),
                cancellationToken);

        if (entity == null)
            throw new NotFoundException(nameof(Domain.Discipline), request.Id);

        _dbContext.Disciplines.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}