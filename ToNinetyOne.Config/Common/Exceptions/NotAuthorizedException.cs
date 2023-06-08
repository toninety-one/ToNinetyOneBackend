namespace ToNinetyOne.Config.Common.Exceptions;

public class NotAuthorizedException : Exception
{
    public const string AuthenticationNotFound = "authentication not found";
    public const string InvalidAuthData = "invalid authenticate data";

    public NotAuthorizedException(string message) : base(message)
    {
    }
}