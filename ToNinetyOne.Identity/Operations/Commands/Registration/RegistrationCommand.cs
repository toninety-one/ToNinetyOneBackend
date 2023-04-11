using MediatR;

namespace ToNinetyOne.Identity.Operations.Commands.Registration;

public class RegistrationCommand : IRequest<Guid>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public RegistrationCommand()
    {
        UserName = "";
        Password = "";
        FirstName = "";
        LastName = "";
        MiddleName = "";
        Password = "";
    }
    
    public RegistrationCommand(string userName, string password, string firstName, string lastName, string middleName)
    {
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }
}