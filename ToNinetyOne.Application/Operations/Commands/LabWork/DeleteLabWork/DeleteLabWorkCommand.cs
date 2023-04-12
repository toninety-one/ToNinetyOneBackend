using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.DeleteLabWork;

public class DeleteLabWorkCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }

    public DeleteLabWorkCommand()
    {
    }

    public DeleteLabWorkCommand(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }
}