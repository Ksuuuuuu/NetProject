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
        var userId = Guid.NewGuid();
        var fileModel = new FormFile(){
            FileName = "testFile"
        };
        var addedFile = fileService.AddFile(userId, fileModel);
        var file = fileService.GetFile(addedFile.Id);
        Assert.AreEqual(fileModel.FileName, file.Name);
    }

    [Test]
    public async Task DeleteUser_AlreadyExisting()
    {
       var userId = Guid.NewGuid();
        var fileModel = new FormFile(){
            FileName = "testFile"
        };
        var addedFile = fileService.AddFile(userId, fileModel);

        Assert.Throws<LogicException>(()=>
            fileService.AddFile(userId, fileModel)
        );
    }
}