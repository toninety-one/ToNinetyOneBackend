using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.User.UpdateUser;

public class UpdateUserCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
}
    
    