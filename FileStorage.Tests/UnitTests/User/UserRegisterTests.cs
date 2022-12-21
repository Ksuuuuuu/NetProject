using FileStorage.Entities.Models;
using FileStorage.Services.Models;
using FileStorage.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FileStorage.Tests;

[TestFixture]
public partial class UserTests
{
    [Test]
    public async Task RegisterUser_Success()
    {
        var model = new RegisterUserModel(){
            Name = "Test1",
            Login = "Test2",
            Password = "Test4",
            Email = "test@test"          
        };

        var resultModel = await authService.RegisterUser(model);
        Assert.AreEqual(model.Login, resultModel.Login);
        Assert.AreEqual(model.Name, resultModel.Name);
        Assert.AreEqual(model.Email, resultModel.Email);

        var user = userRepository.GetById(resultModel.Id);

        var signInManager = services.Get<SignInManager<User>>();
        var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        Assert.AreEqual(result.Succeeded, true);
    }

    [Test]
    public async Task RegisterUser_LoginExists()
    {
        var model = new RegisterUserModel(){
            Login = "Test1",
            Name = "Test2",
            Password = "Test 4",
            Email = "test@test"           
        };

        var resultModel = await authService.RegisterUser(model);
        Assert.ThrowsAsync<LogicException>(async ()=>
        {
            var result2 = await authService.RegisterUser(model); 
        });   
    }

    [Test]
    [TestCaseSource(typeof(UserCaseSource),nameof(UserCaseSource.InvalidPasswords))]
    public async Task RegisterUser_PasswordIsInvalid(string password)
    {
        var model = new RegisterUserModel(){
            Name = "Test1",
            Login = "Test2",
            Password = password,
            Email = "test@test"           
        };

        Assert.ThrowsAsync<LogicException>(async ()=>
        {
            var result = await authService.RegisterUser(model); 
        });   
    }
}