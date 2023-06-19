using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.MarkSubmittedLab;

public class MarkSubmittedLabCommand : IRequest
{
    public Guid UserId { get; set; }
    public string UserRole { get; set; }
    public Guid Id { get; set; }
    public Guid SubId { get; set; }
    public string Mark { get; set; }
}