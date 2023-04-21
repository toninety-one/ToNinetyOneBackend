using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.DeleteSubmittedLab;

public class DeleteSubmittedLabCommandHandler : IRequestHandler<DeleteSubmittedLabCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public DeleteSubmittedLabCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteSubmittedLabCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity =
            await _dbContext.SubmittedLabs
                .Include(s=>s.SelfLabWork)
                .FirstOrDefaultAsync(
                    s => (s.Id == request.SubmittedLabId && s.SelfLabWork.Id == request.Id) ||
                         request.UserRole != Roles.User, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Domain.SubmittedLab), request.Id);

        _dbContext.SubmittedLabs.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}