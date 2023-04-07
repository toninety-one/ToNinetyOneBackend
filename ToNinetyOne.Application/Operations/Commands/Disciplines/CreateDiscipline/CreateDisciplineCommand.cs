using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Disciplines.CreateDiscipline;

public class CreateDisciplineCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
}