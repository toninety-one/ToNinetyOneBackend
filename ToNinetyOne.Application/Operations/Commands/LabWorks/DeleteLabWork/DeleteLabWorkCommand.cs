using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.LabWorks.DeleteLabWork;

public class DeleteLabWorkCommand : IRequest
{
    public Guid DisciplineId { get; set; }
    public Guid Id { get; set; }
}