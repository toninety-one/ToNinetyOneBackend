using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.File.DeleteFile;

public class DeleteFileCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SelfId { get; set; }
    public string UserRole { get; set; }
    public string Type { get; set; }
}