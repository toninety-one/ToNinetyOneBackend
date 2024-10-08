using MediatR;
using Microsoft.AspNetCore.Http;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.CreateLabWork;

public class CreateLabWorkCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid DisciplineId { get; set; }
    public string UserRole { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public IEnumerable<IFormFile> Files { get; set; }
}