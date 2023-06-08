using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

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
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity =
            await _dbContext.LabWorks.FirstOrDefaultAsync(
                labWork => (labWork.Id == request.Id && labWork.SelfDiscipline.UserId == user.Id) ||
                           request.UserRole == Roles.Administrator, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(LabWork), request.Id);

        entity.Title = request.Title;
        entity.Details = request.Details;
        entity.EditDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}