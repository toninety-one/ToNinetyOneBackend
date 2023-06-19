using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.MarkSubmittedLab;

public class MarkSubmittedLabCommandHandler : IRequestHandler<MarkSubmittedLabCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public MarkSubmittedLabCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(MarkSubmittedLabCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity =
            await _dbContext.SubmittedLabs
                .Include(s => s.SelfLabWork)
                .FirstOrDefaultAsync(s => s.Id == request.SubId && s.SelfLabWork.Id == request.Id, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(SubmittedLab), request.SubId);

        entity.Mark = request.Mark;
        entity.EditDate = DateTime.Now;
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}