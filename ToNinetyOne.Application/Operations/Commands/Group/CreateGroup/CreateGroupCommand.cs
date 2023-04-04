using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Group.CreateGroup;

public class CreateGroupCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
}
    
    