using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Utils;

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

        var submitted = _dbContext.SubmittedLabs
            .FirstOrDefault(s => s.SelfUser.Id == request.UserId && s.SelfLabWork.Id == request.LabWorkId);

        if (submitted != null)
        {
            throw new ObjectCountLimitException(nameof(Domain.SubmittedLab), submitted.Id);
        }

        var selfLabWork = _dbContext.LabWorks
            .Include(l => l.SelfDiscipline.Groups)
            .ToList()
            .FirstOrDefault(
                l => l.Id == request.LabWorkId && l.SelfDiscipline.Groups != null &&
                     l.SelfDiscipline.Groups
                         .Any(g => user.UserGroup != null && g.Id == user.UserGroup.Id));

        if (selfLabWork == null) throw new NotFoundException(nameof(LabWork), request.LabWorkId);

        var submittedLab = new Domain.SubmittedLab()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Details = request.Details,
            SelfLabWork = selfLabWork,
            SelfUser = user
        };

        var files = await Task.WhenAll(request.Files.Select(async f =>
            await DownloadFile.Download(f, user.Id, submittedLab.Id, FileTypes.SubmittedLab)));

        await _dbContext.Files.AddRangeAsync(files);
        await _dbContext.SubmittedLabs.AddAsync(submittedLab, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return submittedLab.Id;
    }
}