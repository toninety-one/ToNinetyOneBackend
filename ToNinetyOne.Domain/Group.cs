using System.Text.Json.Serialization;

namespace ToNinetyOne.Domain;

public class Group
{
    public Group()
    {
        Title = "";
        ClassRoom = "";
        CreationDate = DateTime.Now;
        EditDate = DateTime.Now;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ClassRoom { get; set; }
    [JsonIgnore] public ICollection<User>? Users { get; set; } = new List<User>();
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    [JsonIgnore] public ICollection<Discipline>? Disciplines { get; set; } = new List<Discipline>();
}