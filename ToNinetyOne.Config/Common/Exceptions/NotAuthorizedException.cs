namespace ToNinetyOne.Config.Common.Exceptions;

public class NotAuthorizedException : Exception
{
    public NotAuthorizedException(string name, object key) : base($"Entity {name} ({key}) not authorized") { }
}