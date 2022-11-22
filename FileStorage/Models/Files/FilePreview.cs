namespace FileStorage.Models;

public class FilePreview
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    public string Name { get; set; }
}