using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Group.UpdateGroup;

public class UpdateGroupCommand : IRequest
{
    public UpdateGroupCommand()
    {
        Title = "";
    }

    public UpdateGroupCommand(string title)
    {
        Title = title;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
}