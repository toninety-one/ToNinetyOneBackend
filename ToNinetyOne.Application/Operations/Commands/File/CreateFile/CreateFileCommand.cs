using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.File.CreateFile;

public class CreateFileCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
}
    
    