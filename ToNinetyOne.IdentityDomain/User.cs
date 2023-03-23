namespace ToNinetyOne.IdentityDomain;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Guid GroupId { get; set; }
    public Guid AvatarId { get; set; } 
    public Guid Role { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public DateTime RegTime { get; set; }

    public User()
    {
        Id = Guid.NewGuid();
        RegTime = DateTime.Now;
    }
}