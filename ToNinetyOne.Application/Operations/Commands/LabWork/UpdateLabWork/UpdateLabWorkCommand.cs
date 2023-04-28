using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.LabWork.UpdateLabWork;

public class UpdateLabWorkCommand : IRequest
{
    public UpdateLabWorkCommand()
    {
        Title = "";
        Details = "";
    }

    public UpdateLabWorkCommand(string title, string details)
    {
        Title = title;
        Details = details;
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserRole { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
}