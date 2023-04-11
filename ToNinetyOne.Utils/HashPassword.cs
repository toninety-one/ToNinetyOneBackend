using System.Security.Cryptography;
using System.Text;

namespace ToNinetyOne.Utils;

public static class HashPassword
{
    public static string CreateSalt()
    {
        var rng = new RNGCryptoServiceProvider();
        var buff = new byte[32];
        rng.GetBytes(buff);

        return Convert.ToBase64String(buff);
    }

    private static string Hash(string phrase)
    {
        var encoder = new UTF8Encoding();
        var hashedDataBytes = SHA256.HashData(encoder.GetBytes(phrase));
        return Convert.ToBase64String(hashedDataBytes);
    }

    public static string HashWithSalt(string pass, string? salt)
    {
        return Hash(Hash(pass) + salt);
    }
}