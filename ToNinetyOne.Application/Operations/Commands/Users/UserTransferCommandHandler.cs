using MediatR;
using ToNinetyOne.Application.Interfaces;
using ToNinetyOne.Domain;

namespace ToNinetyOne.Application.Operations.Commands.Users;

public class UserTransferCommandHandler : IRequestHandler<UserTransferCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public UserTransferCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(UserTransferCommand request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            Id = request.RegisterId,
            FirstName = "firstname",
            AvatarId = Guid.Empty,
            LastName = "lastname",
            MiddleName = "middlename",
        };
        
        await _dbContext.Users.AddAsync(user, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}