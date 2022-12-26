using FileStorage.Entities.Models;
using FileStorage.Repository;
using FileStorage.Services.Abstract;
using NUnit.Framework;

namespace FileStorage.Tests;

[TestFixture]
public partial class FileTests : UnitTest
{
    private  IFileService fileService;
    private  IRepository<Entities.Models.File> fileRepository;

    public async override Task OneTimeSetUp()
    {
        await base.OneTimeSetUp();
        fileService = services.Get<IFileService>();
        fileRepository = services.Get<IRepository<Entities.Models.File>>();
    }

    
    protected async override Task ClearDb()
    {
        var fileRepository = services.Get<IRepository<Entities.Models.File>>();
        var files = fileRepository.GetAll().ToList();
        foreach(var file in files)
        {
            fileRepository.Delete(file);
        }
    }

}