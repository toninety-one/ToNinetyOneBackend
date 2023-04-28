using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToNinetyOne.Domain;

public class SubmittedLab
{
    public SubmittedLab()
    {
        Id = Guid.NewGuid();
        Title = "";
        Details = "";
        CreationDate = DateTime.Now;
        EditDate = CreationDate;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime EditDate { get; set; }
    public string? Mark { get; set; }
    [Required] public User SelfUser { get; set; }
    [Required] [JsonIgnore] public LabWork SelfLabWork { get; set; }
}