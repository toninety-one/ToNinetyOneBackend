namespace ToNinetyOne.Identity.Data.Interface;

public interface IIdentity
{
    string GenerateRefreshToken(string username);
}