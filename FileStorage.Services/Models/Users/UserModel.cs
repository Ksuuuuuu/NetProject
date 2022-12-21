namespace FileStorage.Services.Models;

public class UserModel : BaseModel
{
    public string Login { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}