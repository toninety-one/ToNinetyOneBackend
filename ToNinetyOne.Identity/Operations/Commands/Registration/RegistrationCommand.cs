using MediatR;

namespace ToNinetyOne.Identity.Operations.Commands.Registration;

public class RegistrationCommand : IRequest<Guid>
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}