using FileStorage.Entities.Models;
using FileStorage.Repository;
using FileStorage.Services.Abstract;
using NUnit.Framework;

namespace FileStorage.Tests;

[TestFixture]
public partial class UserTests : UnitTest
{
    private  IAuthService authService;
    private  IUserService userService;
    private  IRepository<User> userRepository;

    public async override Task OneTimeSetUp()
    {
        await base.OneTimeSetUp();
        authService = services.Get<IAuthService>();
        userService = services.Get<IUserService>();
        userRepository = services.Get<IRepository<User>>();
    }

    
    protected async override Task ClearDb()
    {
        var userRepository = services.Get<IRepository<User>>();
        var users = userRepository.GetAll().ToList();
        foreach(var user in users)
        {
            userRepository.Delete(user);
        }
    }

}