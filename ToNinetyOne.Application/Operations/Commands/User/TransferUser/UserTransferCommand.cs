using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.User.TransferUser;

public class UserTransferCommand : IRequest<Guid>
{
    public UserTransferCommand()
    {
        FirstName = "";
        LastName = "";
        MiddleName = "";
    }

    public UserTransferCommand(Guid registerId) : this()
    {
        RegisterId = registerId;
    }

    public Guid RegisterId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}