using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.SubmittedLab.UpdateSubmittedLab;

public class UpdateSubmittedLabCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
}
    
    