using FileStorage.Services.Models;
using FileStorage.Shared.Exceptions;
using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using Assert = NUnit.Framework.Assert;

namespace FileStorage.Tests;

[TestFixture]
public partial class FileTests
{
    [Test]
    public async Task CreateFile_Success()
    {
        var model = new RegisterUserModel(){
            Name = "Test1",
            Password = "Test2",
            Login = "Test3",
            Email = "test@test",            
        };

        var resultModel = await authService.RegisterUser(model);

        var fileModel = new FormFile(){
            FileName = "testFile"
        };
        var addedFile = fileService.AddFile(resultModel.Id, fileModel);
        var file = fileService.GetFile(addedFile.Id);
        Assert.AreEqual(fileModel.FileName, file.Name);
    }

    [Test]
    public async Task DeleteUser_AlreadyExisting()
    {
          var model = new RegisterUserModel(){
            Name = "Test1",
            Password = "Test2",
            Login = "Test3",
            Email = "test@test",            
        };

        var resultModel = await authService.RegisterUser(model);

        var fileModel = new FormFile(){
            FileName = "testFile"
        };
        var addedFile = fileService.AddFile(resultModel.Id, fileModel);

        Assert.Throws<LogicException>(()=>
            fileService.AddFile(resultModel.Id, fileModel)
        );
    }
}