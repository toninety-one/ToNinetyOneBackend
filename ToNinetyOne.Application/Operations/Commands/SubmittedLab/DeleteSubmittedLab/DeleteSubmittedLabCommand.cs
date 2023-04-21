using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.DeleteSubmittedLab;

public class DeleteSubmittedLabCommand : IRequest
{
    public DeleteSubmittedLabCommand()
    {
    }

    public DeleteSubmittedLabCommand(Guid id, Guid submittedLabId, Guid userId, string userRole)
    {
        Id = id;
        UserId = userId;
        UserRole = userRole;
        SubmittedLabId = submittedLabId;
    }

    public Guid UserId { get; set; }
    public string UserRole { get; set; }
    public Guid Id { get; set; }
    public Guid SubmittedLabId { get; set; }
}