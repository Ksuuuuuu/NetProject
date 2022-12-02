namespace FileStorage.Services.Models;

public class CreateFileModel : BaseModel
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string Extension { get; set; }
    public Guid UserId { get; set; }
}