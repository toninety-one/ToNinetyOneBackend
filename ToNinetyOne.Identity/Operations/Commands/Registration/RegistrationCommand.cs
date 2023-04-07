using MediatR;

namespace ToNinetyOne.Identity.Operations.Commands.Registration;

public class RegistrationCommand : IRequest<Guid>
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public RegistrationCommand()
    {
        UserName = "";
        Password = "";
    }
    
    public RegistrationCommand(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}