using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.LabWorks.UpdateLabWork;

public class UpdateLabWorkCommand : IRequest
{
    public Guid DisciplineId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }
}