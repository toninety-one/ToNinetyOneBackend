using MediatR;
using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Config.Common.Exceptions;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.CreateLabWork;

public class CreateLabWorkCommandHandler : IRequestHandler<CreateLabWorkCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public CreateLabWorkCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateLabWorkCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.UserId);
        }

        var selfDiscipline =
            _dbContext.Disciplines.FirstOrDefault(d =>
                d.Id == request.DisciplineId && d.UserId == request.UserId || user.Role == Roles.Administrator);

        if (selfDiscipline == null)
        {
            throw new NotFoundException(nameof(Domain.Discipline), request.DisciplineId);
        }

        var lab = new Domain.LabWork()
        {
            Details = request.Details,
            FilePath = request.FilePath,
            Title = request.Title,
            SelfDiscipline = selfDiscipline
        };

        await _dbContext.LabWorks.AddAsync(lab, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return lab.Id;
    }
}