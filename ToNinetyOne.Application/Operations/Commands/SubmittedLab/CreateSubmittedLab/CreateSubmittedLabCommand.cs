using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.CreateSubmittedLab;

public class CreateSubmittedLabCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid LabWorkId { get; set; }
    public string UserRole { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }
}