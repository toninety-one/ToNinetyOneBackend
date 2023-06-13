using MediatR;

namespace ToNinetyOne.Identity.Operations.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }
}
    
    