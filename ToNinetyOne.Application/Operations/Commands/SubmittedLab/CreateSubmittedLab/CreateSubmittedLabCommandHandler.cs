using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.CreateSubmittedLab;

public class CreateSubmittedLabCommandHandler : IRequestHandler<CreateSubmittedLabCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public CreateSubmittedLabCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateSubmittedLabCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var selfLabWork =
            await _dbContext.LabWorks.FirstOrDefaultAsync(
                l => l.Id == request.LabWorkId &&
                     _dbContext.Disciplines.Any(d =>
                         d.Groups != null && d.Groups.Any(g => user.UserGroup != null && g.Id == user.UserGroup.Id)),
                cancellationToken);

        if (selfLabWork == null)
        {
            throw new NotFoundException(nameof(LabWork), request.LabWorkId);
        }

        var submittedLab = new Domain.SubmittedLab()
        {
            Details = request.Details,
            FilePath = request.FilePath,
            SelfLabWork = selfLabWork
        };

        await _dbContext.SubmittedLabs.AddAsync(submittedLab, cancellationToken);

        return submittedLab.Id;
    }
}