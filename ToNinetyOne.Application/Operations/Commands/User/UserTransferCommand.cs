using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.User;

public class UserTransferCommand : IRequest<Guid>
{
    public Guid RegisterId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public UserTransferCommand()
    {
        FirstName = "";
        LastName = "";
        MiddleName = "";
    }

    public UserTransferCommand(Guid registerId)
    {
        RegisterId = registerId;
    }
}