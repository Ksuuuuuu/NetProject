namespace FileStorage.Entities.Models;

public class File : BaseEntity
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}