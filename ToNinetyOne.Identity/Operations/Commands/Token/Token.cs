namespace ToNinetyOne.Identity.Operations.Commands.Token;

public class Token
{
    public Token()
    {
        AccessToken = string.Empty;
        RefreshToken = string.Empty;
    }

    public Token(string accessToken, string refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}