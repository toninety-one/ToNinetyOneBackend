using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.UpdateDiscipline;

public class UpdateDisciplineCommand : IRequest
{
    public UpdateDisciplineCommand()
    {
        Title = "";
    }

    public UpdateDisciplineCommand(string title)
    {
        Title = title;
    }

    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
}