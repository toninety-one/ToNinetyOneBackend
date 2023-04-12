namespace ToNinetyOne.Identity.Operations.Commands.Token.Authenticate;

public class AuthenticateResult
{
    public AuthenticateResult()
    {
        UserName = "";
        Role = "";
    }

    public AuthenticateResult(Guid id, string userName, string role)
    {
        Id = id;
        UserName = userName;
        Role = role;
    }

    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
}