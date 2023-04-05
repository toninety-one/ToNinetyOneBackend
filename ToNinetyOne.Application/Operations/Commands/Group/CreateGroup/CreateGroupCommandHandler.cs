using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Commands.Group.CreateGroup;

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public CreateGroupCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = new Domain.Group()
        {
            Title = request.Title,
            Id = Guid.NewGuid(),
            ClassRoom = ""
        };

        await _dbContext.Groups.AddAsync(group, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return group.Id;
    }
}