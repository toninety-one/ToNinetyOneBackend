namespace ToNinetyOne.Domain;

public class LabWork
{
    public Guid DisciplineId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }

    public LabWork()
    {
        CreationDate = DateTime.Now;
        EditDate = CreationDate;
        FilePath = "";
        Title = "";
        Details = "";
    }
}