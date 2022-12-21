namespace FileStorage.Models;

public abstract class AuthUserRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
}
