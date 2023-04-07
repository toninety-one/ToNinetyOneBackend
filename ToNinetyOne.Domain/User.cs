using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ToNinetyOne.Domain;

public class User
{
    [Key]
    [Required]
    [NotNull]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    [ForeignKey(nameof(UserGroup))]
    public Guid? GroupId { get; set; }
    [JsonIgnore]
    public Group? UserGroup { get; set; }
    public Guid AvatarId { get; set; }

    public User(){}
    
    public User(Guid registerId)
    {
        Id = registerId;
    }
}