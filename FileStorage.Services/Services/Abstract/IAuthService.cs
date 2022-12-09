using FileStorage.Services.Models;
using IdentityModel.Client;

namespace FileStorage.Services.Abstract;

public interface IAuthService
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);
}
