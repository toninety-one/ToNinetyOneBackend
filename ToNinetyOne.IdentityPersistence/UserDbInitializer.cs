namespace ToNinetyOne.IdentityPersistence;

public static class UserDbInitializer
{
    private static void CreateDefaultUsers(ToNinetyOneUserDbContext context)
    {
        context.SaveChanges();
    }

    public static void Initialize(ToNinetyOneUserDbContext context)
    {
        context.Database.EnsureCreated();
        context.SaveChanges();

        CreateDefaultUsers(context);
    }
}