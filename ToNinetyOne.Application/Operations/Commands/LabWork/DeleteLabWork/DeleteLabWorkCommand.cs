using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.DeleteLabWork;

public class DeleteLabWorkCommand : IRequest
{
    public DeleteLabWorkCommand()
    {
    }

    public DeleteLabWorkCommand(Guid id, Guid userId)
    {
        Id = id;
        UserId = userId;
    }

    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}