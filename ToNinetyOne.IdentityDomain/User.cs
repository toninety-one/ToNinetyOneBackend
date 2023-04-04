using System.Text.RegularExpressions;

namespace ToNinetyOne.IdentityDomain;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public Guid RoleId { get; set; }
    // public Role UserRole { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public DateTime RegTime { get; set; }

    public User()
    {
        Id = Guid.NewGuid();
        RegTime = DateTime.Now;
    }
}