namespace ToNinetyOne.Domain;

public class Group
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ClassRoom { get; set; }
    public IEnumerable<User>? Users { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }

    public Group()
    {
        CreationDate = DateTime.Now;
        EditDate = DateTime.Now;
    }
}