namespace ToNinetyOne.IdentityDomain;

public class RefreshToken
{
    public RefreshToken(string userName, string token)
    {
        Id = Guid.NewGuid();
        UserName = userName;
        Token = token;
        IsActive = true;
    }

    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public bool IsActive { get; set; }
}