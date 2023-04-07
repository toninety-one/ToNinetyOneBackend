using MediatR;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Update;

public class UpdateCommand : IRequest<string>
{
    public string UserName { get; set; }
    public string RefreshToken { get; set; }
    public UpdateCommand()
    {
        UserName = "";
        RefreshToken = "";
    }
    
    public UpdateCommand(string userName, string refreshToken)
    {
        UserName = userName;
        RefreshToken = refreshToken;
    }
}