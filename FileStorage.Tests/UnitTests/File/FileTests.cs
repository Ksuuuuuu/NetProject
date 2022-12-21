using FileStorage.Entities.Models;
using FileStorage.Repository;
using FileStorage.Services.Abstract;
using NUnit.Framework;

namespace FileStorage.Tests;

[TestFixture]
public partial class FileTests : UnitTest
{
    private  IAuthService authService;
    private  IUserService userService;
    private  IRepository<User> userRepository;
    private  IFileService fileService;
    private  IRepository<Entities.Models.File> fileRepository;

    public async override Task OneTimeSetUp()
    {
        await base.OneTimeSetUp();
        authService = services.Get<IAuthService>();
        userService = services.Get<IUserService>();
        userRepository = services.Get<IRepository<User>>();
        fileService = services.Get<IFileService>();
        fileRepository = services.Get<IRepository<Entities.Models.File>>();
    }

    
    protected async override Task ClearDb()
    {
        var userRepository = services.Get<IRepository<User>>();
        var users = userRepository.GetAll().ToList();
        foreach(var user in users)
        {
            userRepository.Delete(user);
        }

        var fileRepository = services.Get<IRepository<Entities.Models.File>>();
        var files = fileRepository.GetAll().ToList();
        foreach(var file in files)
        {
            fileRepository.Delete(file);
        }
    }

}