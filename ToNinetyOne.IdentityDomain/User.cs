namespace ToNinetyOne.IdentityDomain;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public DateTime RegTime { get; set; }

    public User()
    {
        Id = Guid.NewGuid();
        RegTime = DateTime.Now;
        UserName = "";
        Role = "";
        Password = "";
        Salt = "";
    }
}