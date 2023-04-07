using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.LabWorks.CreateLabWork;

public class CreateLabWorkCommand : IRequest<Guid>
{
    public Guid DisciplineId { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }

    public CreateLabWorkCommand()
    {
        Title = "";
        Details = "";
        FilePath = "";
    }

    public CreateLabWorkCommand(Guid disciplineId, string title, string details, string filePath)
    {
        DisciplineId = disciplineId;
        Title = title;
        Details = details;
        FilePath = filePath;
    }
}