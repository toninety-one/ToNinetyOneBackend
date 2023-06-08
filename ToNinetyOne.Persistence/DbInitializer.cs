namespace ToNinetyOne.Persistence;

public static class DbInitializer
{
    public static void Initialize(ToNinetyOneDbContext context)
    {
        context.Database.EnsureCreated();
    }
}