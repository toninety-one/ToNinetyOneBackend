using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.UpdateSubmittedLab;

public class UpdateSubmittedLabCommand : IRequest
{
    public Guid UserId { get; set; }
    public string UserRole { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }
    public Guid SelfLabId { get; set; }
}