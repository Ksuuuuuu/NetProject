using AutoMapper;
using FileStorage.Entities.Models;
using FileStorage.Repository;
using FileStorage.Services.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using FileStorage.Services.Abstract;
using FileStorage.Shared.Exceptions;
using FileStorage.Shared.ResultCodes;

namespace FileStorage.Services.Implementation;

public class AuthService : IAuthService
{
    #region Fields
    private readonly IRepository<User> usersRepository;
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IMapper mapper;
    private readonly string identityUri;

    #endregion
    public AuthService(
        IRepository<User> usersRepository, UserManager<User> userManager, SignInManager<User> signInManager,
        IMapper mapper, IConfiguration configuration)
    {
        this.usersRepository = usersRepository;
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.mapper = mapper;
        identityUri = configuration.GetValue<string>("IdentityServer:Uri");
    }
    public async Task<UserModel> RegisterUser(RegisterUserModel model)
    {
        var existingUser = usersRepository.GetAll(f => f.Login == model.Login).FirstOrDefault();
        if (existingUser != null)
        {
            throw new LogicException(ResultCode.USER_ALREADY_EXISTS);
        }

        var user = new User()
        {
            Login = model.Login,
            Email = model.Email,
            UserName = model.Login,
            Name = model.Name ?? "",
            PasswordHash = model.Password,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        var createdUser = usersRepository.GetAll(f => f.Login == model.Login).FirstOrDefault();
        return mapper.Map<UserModel>(createdUser);
    }

    public async Task<IdentityModel.Client.TokenResponse> LoginUser(LoginUserModel model)
    {
        var user = usersRepository.GetAll(f => f.Login == model.Login).FirstOrDefault();
        if (user == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.EMAIL_OR_PASSWORD_IS_INCORRECT);
        }

        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(identityUri);
        if (disco.IsError)
        {
            throw new Exception(disco.Error);
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = model.ClientId,
            ClientSecret = model.ClientSecret,
            UserName = model.Login,
            Password = model.Password,
            Scope = "api offline_access"
        });

        if (tokenResponse.IsError)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        return tokenResponse;
    }
}