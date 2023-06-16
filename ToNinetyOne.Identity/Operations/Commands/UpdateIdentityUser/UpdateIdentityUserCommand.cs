using MediatR;

namespace ToNinetyOne.Identity.Operations.Commands.UpdateIdentityUser;

public class UpdateIdentityUserCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }
}
    
    