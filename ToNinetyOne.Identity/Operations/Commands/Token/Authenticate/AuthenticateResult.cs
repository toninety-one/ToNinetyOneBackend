using ToNinetyOne.IdentityDomain;

namespace ToNinetyOne.Identity.Operations.Commands.Token.Authenticate;

public class AuthenticateResult
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public Role Role { get; set; }
}