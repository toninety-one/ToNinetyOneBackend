namespace ToNinetyOne.UserPersistence;

public class UserDbInitializer
{
    public static void Initialize(ToNinetyOneUserDbContext context)
    {
        context.Database.EnsureCreated();
    }
}