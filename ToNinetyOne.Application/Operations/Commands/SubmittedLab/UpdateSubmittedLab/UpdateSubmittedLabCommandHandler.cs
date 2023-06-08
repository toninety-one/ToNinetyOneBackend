using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.UpdateSubmittedLab;

public class UpdateSubmittedLabCommandHandler : IRequestHandler<UpdateSubmittedLabCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public UpdateSubmittedLabCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateSubmittedLabCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity =
            await _dbContext.SubmittedLabs
                .Include(s => s.SelfUser)
                .FirstOrDefaultAsync(
                    s => s.Id == request.Id && (s.SelfUser.Id == user.Id || request.UserRole != Roles.User),
                    cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(SubmittedLab), request.Id);
        
        var selfLab = await _dbContext.LabWorks.FirstOrDefaultAsync(l => l.Id == request.SelfLabId, cancellationToken);

        if (selfLab == null) throw new NotFoundException(nameof(LabWork), request.SelfLabId);
        
        entity.Title = request.Title;
        entity.Details = request.Details;
        entity.EditDate = DateTime.Now;
        entity.SelfLabWork = selfLab;

        return Unit.Value;
    }
}