using System.Text.Json.Serialization;

namespace ToNinetyOne.Domain;

public class Discipline
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string FilePath { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    [JsonIgnore] public ICollection<Group>? Groups { get; set; } = new List<Group>();
    [JsonIgnore] public ICollection<LabWork>? LabWorks { get; set; } = new List<LabWork>();

    public Discipline()
    {
        CreationDate = DateTime.Now;
        EditDate = CreationDate;
        Title = "";
        FilePath = "";
    }
}