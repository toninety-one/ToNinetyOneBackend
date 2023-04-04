using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Domain;
        
namespace ToNinetyOne.Application.Operations.Commands.Group.UpdateGroup;
        
public class  UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;
        
    public UpdateGroupCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Groups.FirstOrDefaultAsync(discipline => discipline.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Domain.Group), request.Id);
        }

        entity.Title = request.Title;
        entity.EditDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
