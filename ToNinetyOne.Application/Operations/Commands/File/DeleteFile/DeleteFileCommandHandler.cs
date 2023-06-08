using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Application.Operations.Commands.File.DeleteFile;

public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public DeleteFileCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var entity = await _dbContext.Files.FirstOrDefaultAsync(
            f => f.Id == request.Id && f.FileType == request.Type &&
                 (f.UserId == request.UserId || request.UserRole == Roles.Administrator),
            cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Domain.File), request.Id);

        _dbContext.Files.Remove(entity);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}