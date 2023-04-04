using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Users;

public class UserTransferCommand : IRequest<Guid>
{
    public Guid RegisterId { get; set; }
}