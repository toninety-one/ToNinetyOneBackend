using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.DeleteDiscipline;

public class DeleteDisciplineCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}