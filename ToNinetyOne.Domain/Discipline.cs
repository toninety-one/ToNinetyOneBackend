namespace ToNinetyOne.Domain;

public class Discipline
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }

    public Discipline()
    {
        CreationDate = DateTime.Now;
        EditDate = CreationDate;
    }
}