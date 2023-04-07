namespace ToNinetyOne.IdentityDomain;

public class JwtSetting
{
    public JwtSetting()
    {
        SecurityKey = "";
    }

    public JwtSetting(string securityKey)
    {
        SecurityKey = securityKey;
    }

    public string SecurityKey { get; set; }

    public string Encrypt(string refreshToken)
    {
        var crypt = new char[refreshToken.Length];

        for (var i = 0; i < refreshToken.Length; i++)
        {
            crypt[i] = (char)(refreshToken[i] + SecurityKey[i % SecurityKey.Length]);
        }

        return new string(crypt);
    }

    public string Decrypt(string cookieRefreshToken)
    {
        var crypt = new char[cookieRefreshToken.Length];

        for (var i = 0; i < cookieRefreshToken.Length; i++)
        {
            crypt[i] = (char)(cookieRefreshToken[i] - SecurityKey[i % SecurityKey.Length]);
        }

        return new string(crypt);
    }
}