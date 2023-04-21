using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using ToNinetyOne.Config.Static;

namespace ToNinetyOne.Domain;

public class User
{
    public User()
    {
        FirstName = "";
        LastName = "";
        MiddleName = "";
    }

    public User(Guid registerId) : this()
    {
        Id = registerId;
    }

    public User(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    [Key] [Required] [NotNull] public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    [ForeignKey(nameof(UserGroup))] public Guid? GroupId { get; set; }
    [JsonIgnore] public Group? UserGroup { get; set; }
}