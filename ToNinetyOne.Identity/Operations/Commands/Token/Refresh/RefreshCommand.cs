using MediatR;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Refresh;

public class RefreshCommand : IRequest<string>
{
    public string UserName { get; set; }
}