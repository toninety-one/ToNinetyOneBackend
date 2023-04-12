using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Discipline.UpdateDiscipline;

public class UpdateDisciplineCommand : IRequest
{
    public UpdateDisciplineCommand()
    {
        Title = "";
        FilePath = "";
    }

    public UpdateDisciplineCommand(string title, string filePath)
    {
        Title = title;
        FilePath = filePath;
    }

    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
}