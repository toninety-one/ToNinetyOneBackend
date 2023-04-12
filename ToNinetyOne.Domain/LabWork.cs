using System.Text.Json.Serialization;

namespace ToNinetyOne.Domain;

public class LabWork
{
    public LabWork()
    {
        CreationDate = DateTime.Now;
        EditDate = CreationDate;
        FilePath = "";
        Title = "";
        Details = "";
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string FilePath { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    [JsonIgnore] public Discipline SelfDiscipline { get; set; }
    [JsonIgnore] public ICollection<SubmittedLab>? SubmittedLabs { get; set; } = new List<SubmittedLab>();
}