using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

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
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity =
            await _dbContext.LabWorks.FirstOrDefaultAsync(
                labWork => (labWork.Id == request.Id && labWork.SelfDiscipline.UserId == user.Id) ||
                           user.Role == Roles.Administrator, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(LabWork), request.Id);

        _dbContext.LabWorks.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}