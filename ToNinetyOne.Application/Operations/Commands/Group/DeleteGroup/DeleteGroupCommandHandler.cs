using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Commands.Group.DeleteGroup;

public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public DeleteGroupCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Groups.FirstOrDefaultAsync(discipline => discipline.Id == request.Id, cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Domain.Group), request.Id);

        _dbContext.Groups.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}