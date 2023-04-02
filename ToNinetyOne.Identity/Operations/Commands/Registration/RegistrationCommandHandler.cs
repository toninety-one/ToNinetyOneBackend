using AutoMapper.QueryableExtensions;
using MediatR;
using ToNinetyOne.Identity.Interfaces;
using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.Identity.Operations.Commands.Registration;

public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, Guid>
{
    private readonly IToNinetyOneUserDbContext _dbContext;

    public RegistrationCommandHandler(IToNinetyOneUserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.UserName,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.FirstName,
            RoleId = Guid.Empty,
            Password = request.Password,
            Salt = request.FirstName,
            AvatarId = Guid.Empty,
            GroupId = Guid.Empty,
        };

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}