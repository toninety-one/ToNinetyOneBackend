namespace ToNinetyOne.Identity.Operations.Commands.Token;

public class Token
{
    public Token()
    {
        JwtToken = string.Empty;
        RefreshToken = string.Empty;
    }

    public Token(string jwtToken, string refreshToken)
    {
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
    }

    public string JwtToken { get; set; }
    public string RefreshToken { get; set; }
}