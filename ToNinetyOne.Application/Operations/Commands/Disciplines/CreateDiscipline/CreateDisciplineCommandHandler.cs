using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Commands.Disciplines.CreateDiscipline;

public class  CreateDisciplineCommandHandler : IRequestHandler<CreateDisciplineCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public CreateDisciplineCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateDisciplineCommand request, CancellationToken cancellationToken)
    {
        var discipline = new Discipline
        {
            UserId = request.UserId,
            Title = request.Title,
            Id = Guid.NewGuid(),
            FilePath = request.FilePath,
        };

        await _dbContext.Disciplines.AddAsync(discipline, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return discipline.Id;
    }
}