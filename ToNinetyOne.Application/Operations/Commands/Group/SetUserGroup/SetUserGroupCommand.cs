using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Group.SetUserGroup;

public class SetUserGroupCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid GroupId { get; set; }}
    
    