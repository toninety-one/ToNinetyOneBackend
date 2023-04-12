using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.UpdateLabWork;

public class UpdateLabWorkCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }

    public UpdateLabWorkCommand()
    {
        Title = "";
        Details = "";
        FilePath = "";
    }

    public UpdateLabWorkCommand(string title, string details, string filePath)
    {
        Title = title;
        Details = details;
        FilePath = filePath;
    }
}