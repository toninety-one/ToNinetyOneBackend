namespace ToNinetyOne.Config.Common.Exceptions;

public class ObjectCountLimitException : Exception
{
    public ObjectCountLimitException(string name, object key) : base($"Entity {name} have object with id {key}. You cannot create more entities. Try update entity with id = {key}")
    {
    }
}