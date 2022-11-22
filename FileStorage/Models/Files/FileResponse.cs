namespace FileStorage.Models;

public class FileResponse
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
     public string Extension { get; set; }

}