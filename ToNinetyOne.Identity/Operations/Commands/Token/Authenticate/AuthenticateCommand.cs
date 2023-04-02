using MediatR;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Authenticate;

public class AuthenticateCommand : IRequest<AuthenticateResult>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}