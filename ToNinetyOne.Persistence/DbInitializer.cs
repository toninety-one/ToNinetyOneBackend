using ToNinetyOne.Domain;

namespace ToNinetyOne.Persistence;

public static class DbInitializer
{
    public static void Initialize(ToNinetyOneDbContext context, Guid adminId)
    {
        context.Database.EnsureCreated();

        if (!context.Users.Any(u => u.Id == adminId))
        {
            context.Users.Add(new User(adminId) { FirstName = "admin", LastName = "admin", MiddleName = "admin" });
            context.SaveChanges();
        }
    }
}