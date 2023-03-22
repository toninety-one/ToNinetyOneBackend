namespace ToNinetyOne.UserPersistence;

public static class UserDbInitializer
{
    public static void Initialize(ToNinetyOneUserDbContext context)
    {
        context.Database.EnsureCreated();
    }
}