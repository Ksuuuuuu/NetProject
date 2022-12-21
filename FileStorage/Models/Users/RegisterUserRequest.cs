namespace FileStorage.Models;

public class RegisterUserRequest : AuthUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
}