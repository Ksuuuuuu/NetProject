namespace FileStorage.Entities.Models;

public class User : BaseEntity
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    
    public virtual ICollection<File> Files { get; set; }
}
