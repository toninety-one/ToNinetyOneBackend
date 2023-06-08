using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.CreateDiscipline;

public class CreateDisciplineCommand : IRequest<Guid>
{
    public CreateDisciplineCommand()
    {
        Title = "";
    }

    public CreateDisciplineCommand(Guid userId, string title)
    {
        UserId = userId;
        Title = title;
    }

    public Guid UserId { get; set; }
    public string Title { get; set; }
}