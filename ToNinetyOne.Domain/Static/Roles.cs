using System.Reflection;
using ToNinetyOne.Domain.Auth;

namespace ToNinetyOne.Domain.Static;

public class Roles
{
    public const string User = "User";
    public const string Teacher = "Teacher";
    public const string Administrator = "Administrator";

    public static List<string> Fields => 
        new List<FieldInfo>(typeof(Roles)
                .GetFields(BindingFlags.Static | BindingFlags.Public))
            .Select(item => item.Name.ToString()).ToList();
}