using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.LabWorks.UpdateLabWork;

public class UpdateLabWorkCommand : IRequest
{
    public Guid DisciplineId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }

    public UpdateLabWorkCommand()
    {
        Title = "";
        Details = "";
        FilePath = "";
    }

    public UpdateLabWorkCommand(Guid disciplineId, Guid id, string title, string details, string filePath)
    {
        DisciplineId = disciplineId;
        Id = id;
        Title = title;
        Details = details;
        FilePath = filePath;
    }
}