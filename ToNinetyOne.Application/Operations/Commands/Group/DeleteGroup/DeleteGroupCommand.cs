using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Group.DeleteGroup;

public class DeleteGroupCommand : IRequest
{
    public Guid Id { get; set; }
}
    
    