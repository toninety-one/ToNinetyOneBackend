using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.DisciplineGroup.AddDisciplineGroup;

public class AddDisciplineGroupCommand : IRequest<Guid>
{
    public Guid GroupId { get; set; }
    public Guid DisciplineId { get; set; }
}