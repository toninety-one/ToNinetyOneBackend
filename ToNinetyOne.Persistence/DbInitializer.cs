namespace ToNinetyOne.Persistence;

public class DbInitializer
{
    public static void Initialize(ToNinetyOneDbContext context)
    {
        context.Database.EnsureCreated();
    }
}