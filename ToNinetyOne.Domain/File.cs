using System.ComponentModel.DataAnnotations;

namespace ToNinetyOne.Domain;

public class File
{
    [Required] public Guid Id { get; set; }
    public string FileName { get; set; }
    public Guid? UserId { get; set; }
    [Required] public string Path { get; set; } = "";
    public string? FileType { get; set; }
    public Guid SelfId { get; set; }
}