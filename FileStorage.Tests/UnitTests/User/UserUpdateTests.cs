using FileStorage.Services.Models;
using FileStorage.Shared.Exceptions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FileStorage.Tests;

[TestFixture]
public partial class UserTests
{
    [Test]
    public async Task UpdateUser_Success()
    {
        var model = new RegisterUserModel(){
            Name = "Test1",
            Password = "Test2",
            Login = "Test3",
            Email = "test@test",            
        };

        var updateModel = new UpdateUserModel(){
            Email = "new email test"
        };

        var resultModel = await authService.RegisterUser(model);
        var updatedUser = userService.UpdateUser(resultModel.Id, updateModel);
        var user = userService.GetUser(resultModel.Id);

        Assert.AreEqual(updatedUser.Email, user.Email);
    }

    [Test]
    public async Task UpdateUser_NotExisting()
    {
        var randomGuid = Guid.NewGuid();

        var updateUser = new UpdateUserModel(){
            Name = "new name"
        };
        Assert.Throws<LogicException>(()=>
            userService.UpdateUser(randomGuid, updateUser)
        );
    }
}