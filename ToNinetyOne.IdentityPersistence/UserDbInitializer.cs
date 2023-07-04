using Microsoft.EntityFrameworkCore;
using ToNinetyOne.Config.Static;
using ToNinetyOne.IdentityDomain;
using ToNinetyOne.Utils;

namespace ToNinetyOne.IdentityPersistence;

public static class UserDbInitializer
{
    private static Guid CreateDefaultUsers(ToNinetyOneUserDbContext context, string authKey)
    {
        if (!context.Users.Any(u => u.UserName == "admin"))
        {
            var salt = HashPassword.CreateSalt();

            context.Users.Add(new User()
            {
                UserName = "admin", Role = Roles.Administrator,
                Password = HashPassword.HashWithSalt(authKey, salt),
                Salt = salt
            });
        }

        context.SaveChanges();

        return context.Users.FirstOrDefault(u => u.UserName == "admin")!.Id;
    }

    public static Guid Initialize(ToNinetyOneUserDbContext context, string authKey)
    {
        context.Database.EnsureCreated();
        context.SaveChanges();

        return CreateDefaultUsers(context, authKey);
    }
}