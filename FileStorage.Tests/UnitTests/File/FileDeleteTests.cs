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
        var userId = Guid.NewGuid();
        var fileModel = new FormFile(){
            FileName = "testFile"
        };
        var addedFile = fileService.AddFile(userId, fileModel);

        fileService.DeleteFile(addedFile.Id);

        Assert.Throws<LogicException>(()=>
            {
                var checkFile = fileService.GetFile(addedFile.Id);
            }
        );
    }

    [Test]
    public async Task DeleteFile_NotExisting()
    {
        var randomGuid = Guid.NewGuid();
        Assert.Throws<LogicException>(()=>
            fileService.DeleteFile(randomGuid)
        );
    }
}