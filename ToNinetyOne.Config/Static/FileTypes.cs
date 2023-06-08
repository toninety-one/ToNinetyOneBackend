using System.Reflection;

namespace ToNinetyOne.Config.Static;

public class FileTypes
{
    public const string LabWork = "User";
    public const string SubmittedLab = "Teacher";

    public static List<string> Fields =>
        new List<FieldInfo>(typeof(FileTypes)
                .GetFields(BindingFlags.Static | BindingFlags.Public))
            .Select(item => item.Name.ToString()).ToList();
}