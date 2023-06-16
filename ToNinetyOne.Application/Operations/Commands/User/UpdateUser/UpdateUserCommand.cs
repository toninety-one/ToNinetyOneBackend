using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.User.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public Guid? GroupId { get; set; }
}
    
    