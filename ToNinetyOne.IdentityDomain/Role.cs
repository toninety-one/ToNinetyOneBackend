namespace ToNinetyOne.IdentityDomain;

public class Role
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public override string ToString()
    {
        return Title;
    }
}