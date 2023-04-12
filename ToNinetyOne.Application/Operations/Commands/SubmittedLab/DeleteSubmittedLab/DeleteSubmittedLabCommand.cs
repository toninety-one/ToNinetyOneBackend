using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.DeleteSubmittedLab;

public class DeleteSubmittedLabCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
}