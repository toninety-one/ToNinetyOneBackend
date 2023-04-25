using MediatR;
using ToNinetyOne.Application.Interfaces;

namespace ToNinetyOne.Application.Operations.Commands.User.TransferUser;

public class UserTransferCommandHandler : IRequestHandler<UserTransferCommand, Guid>
{
    private readonly IToNinetyOneDbContext _dbContext;

    public UserTransferCommandHandler(IToNinetyOneDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(UserTransferCommand request, CancellationToken cancellationToken)
    {
        var user = new Domain.User
        {
            Id = request.RegisterId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
        };

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}