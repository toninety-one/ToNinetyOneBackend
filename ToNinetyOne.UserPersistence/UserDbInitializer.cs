using ToNinetyOne.IdentityDomain;
using ToNinetyOne.IdentityDomain.Static;

namespace ToNinetyOne.UserPersistence;

public static class UserDbInitializer
{
    private static void CreateRoles(ToNinetyOneUserDbContext context)
    {
        foreach (var role in Roles.Fields.Where(role => context.Roles.FirstOrDefault(r => r.Title == role) == null))
            context.Roles.Add(new Role { Id = Guid.NewGuid(), Title = role });

        context.SaveChanges();
    }

    private static void CreateDefaultUsers(ToNinetyOneUserDbContext context)
    {
        context.SaveChanges();
    }

    public static void Initialize(ToNinetyOneUserDbContext context)
    {
        context.Database.EnsureCreated();

        CreateRoles(context);

        CreateDefaultUsers(context);
    }
}