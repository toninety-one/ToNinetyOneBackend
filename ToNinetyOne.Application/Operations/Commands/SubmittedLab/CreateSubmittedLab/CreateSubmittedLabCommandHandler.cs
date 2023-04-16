using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

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
        var user = await _dbContext.Users
            .Include(u => u.UserGroup)
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null) throw new NotFoundException(nameof(User), request.UserId);

        var selfLabWork = _dbContext.LabWorks
            .Include(l => l.SelfDiscipline.Groups)
            .ToList()
            .FirstOrDefault(
                l => l.Id == request.LabWorkId && (request.UserRole == Roles.Administrator ||
                                                   l.SelfDiscipline.Groups != null && l.SelfDiscipline.Groups.Any(g =>
                                                       user.UserGroup != null && g.Id == user.UserGroup.Id)));

        if (selfLabWork == null) throw new NotFoundException(nameof(LabWork), request.LabWorkId);

        var submittedLab = new Domain.SubmittedLab()
        {
            Details = request.Details,
            FilePath = request.FilePath,
            SelfLabWork = selfLabWork,
            SelfUser = user
        };

        await _dbContext.SubmittedLabs.AddAsync(submittedLab, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return submittedLab.Id;
    }
}