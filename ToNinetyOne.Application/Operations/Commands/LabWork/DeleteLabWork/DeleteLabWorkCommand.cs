using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.DeleteLabWork;

public class DeleteLabWorkCommand : IRequest
{
    public DeleteLabWorkCommand()
    {
    }

    public DeleteLabWorkCommand(Guid id, Guid userId, string userRole)
    {
        Id = id;
        UserId = userId;
        UserRole = userRole;
    }

    public Guid UserId { get; set; }
    public string UserRole { get; set; }
    public Guid Id { get; set; }
}