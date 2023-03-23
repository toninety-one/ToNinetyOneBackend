namespace ToNinetyOne.Identity.Data.Interface;

public interface IRefreshTokenGenerator
{
    string GenerateToken(string username);
}