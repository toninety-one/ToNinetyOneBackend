namespace ToNinetyOne.IdentityDomain;

public class TokenResponse
{
    public string JwtToken { get; set; }
    public string RefreshToken { get; set; }

    public TokenResponse()
    {
        JwtToken = string.Empty;
        RefreshToken = string.Empty;
    }
    
    public TokenResponse(string jwtToken, string refreshToken) : base()
    {
        JwtToken = jwtToken;
        RefreshToken = refreshToken;
    }
}