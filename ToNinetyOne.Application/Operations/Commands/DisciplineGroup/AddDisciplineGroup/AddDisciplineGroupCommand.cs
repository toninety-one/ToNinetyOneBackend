using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.DisciplineGroup.AddDisciplineGroup;

public class AddDisciplineGroupCommand : IRequest
{
    public Guid GroupId { get; set; }
    public Guid DisciplineId { get; set; }
}