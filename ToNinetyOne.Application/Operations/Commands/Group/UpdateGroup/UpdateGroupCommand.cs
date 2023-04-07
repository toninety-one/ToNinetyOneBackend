using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Group.UpdateGroup;

public class UpdateGroupCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}
    
    