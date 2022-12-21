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
    public async Task DeleteFile_Success()
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

        fileService.DeleteFile(addedFile.Id);


        Assert.Throws<LogicException>(()=>
            {
                var checkFile = fileService.GetFile(addedFile.Id);
            }
        );
    }

    [Test]
    public async Task DeleteUser_NotExisting()
    {
        var randomGuid = Guid.NewGuid();
        Assert.Throws<LogicException>(()=>
            fileService.DeleteFile(randomGuid)
        );
    }
}