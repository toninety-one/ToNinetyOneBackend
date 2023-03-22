using ToNinetyOne.Domain.Auth;
using ToNinetyOne.Domain.Static;

namespace ToNinetyOne.UserPersistence;

public static class UserDbInitializer
{
    private static void CreateRoles(ToNinetyOneUserDbContext context)
    {
        foreach (var role in Roles.Fields)
        {
            if (context.Roles.FirstOrDefault(r=>r.Title == role) == null)
            {
                context.Roles.Add(new Role() { Id = Guid.NewGuid(), Title = role });
            }
        }
    }

    public static void Initialize(ToNinetyOneUserDbContext context)
    {
        context.Database.EnsureCreated();

        CreateRoles(context);
    }
}