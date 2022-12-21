using Microsoft.AspNetCore.Identity;

namespace FileStorage.Entities.Models;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public string Login { get; set; }
   // public string PasswordHash { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public virtual ICollection<File> Files { get; set; }

    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }

}


public class UserRole : IdentityRole<Guid>
{ }

