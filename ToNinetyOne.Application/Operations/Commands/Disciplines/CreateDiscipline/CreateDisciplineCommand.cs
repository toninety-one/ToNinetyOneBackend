using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Disciplines.CreateDiscipline;

public class CreateDisciplineCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }

    public CreateDisciplineCommand()
    {
        Title = "";
        FilePath = "";
    }

    public CreateDisciplineCommand(Guid userId, string title, string filePath)
    {
        UserId = userId;
        Title = title;
        FilePath = filePath;
    }
}