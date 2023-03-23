namespace ToNinetyOne.IdentityDomain;

public class RefreshToken
{

    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public bool IsActive { get; set; }
    
    public RefreshToken(string userName, string token)
    {
        Id = Guid.NewGuid();
        UserName = userName;
        Token = token;
        IsActive = true;
    }
}