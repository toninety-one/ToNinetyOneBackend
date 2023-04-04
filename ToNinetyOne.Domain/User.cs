namespace ToNinetyOne.Domain;

public class User
{
    public Guid Id { get; set; }
    public Guid SelfId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Group Group { get; set; }
    public Guid AvatarId { get; set; }

    public User(){}
    
    public User(Guid registerId)
    {
        SelfId = registerId;
    }
}