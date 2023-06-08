using MediatR;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Refresh;

public class RefreshCommand : IRequest<string>
{
    public RefreshCommand()
    {
        UserName = "";
    }

    public RefreshCommand(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }
}