using MediatR;
using ToNinetyOne.Config.Static;
using ToNinetyOne.Identity.Interfaces;
using ToNinetyOne.IdentityDomain;
using ToNinetyOne.Utils;

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
        var salt = HashPassword.CreateSalt();

        var user = new User
        {
            UserName = request.UserName,
            Role = Roles.User,
            Password = HashPassword.HashWithSalt(request.Password, salt),
            Salt = salt
        };

        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}