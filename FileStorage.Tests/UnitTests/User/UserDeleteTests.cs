using FileStorage.Services.Models;
using FileStorage.Shared.Exceptions;
using NUnit.Framework;

using Assert = NUnit.Framework.Assert;

namespace FileStorage.Tests;

[TestFixture]
public partial class UserTests
{
    [Test]
    public async Task DeleteUser_Success()
    {
        var model = new RegisterUserModel(){
            Name = "Test1",
            Password = "Test2",
            Login = "Test3",
            Email = "test@test",            
        };

        var resultModel = await authService.RegisterUser(model);
        userService.DeleteUser(resultModel.Id);

        Assert.Throws<LogicException>(()=>
            {
                var checkUser = userService.GetUser(resultModel.Id);
            }
        );
    }

    [Test]
    public async Task DeleteUser_NotExisting()
    {
        var randomGuid = Guid.NewGuid();
        Assert.Throws<LogicException>(()=>
            userService.DeleteUser(randomGuid)
        );
    }
}