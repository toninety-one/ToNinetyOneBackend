using MediatR;

namespace ToNinetyOne.Application.Operations.Commands.Group.CreateGroup;

public class CreateGroupCommand : IRequest<Guid>
{
    public CreateGroupCommand()
    {
        Title = "";
    }

    public CreateGroupCommand(string title)
    {
        Title = title;
    }

    public Guid UserId { get; set; }
    public string Title { get; set; }
}