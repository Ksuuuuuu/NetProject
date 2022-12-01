using AutoMapper;
using Microsoft.AspNetCore.Http;
using FileStorage.Repository;
using FileStorage.Services.Abstract;
using FileStorage.Services.Models;
using Microsoft.AspNetCore.Hosting;

namespace FileStorage.Services.Implementation;

public class FileService : IFileService
{
    private readonly IRepository<Entities.Models.File> filesRepository;
    private readonly IMapper mapper;
    private readonly IHostingEnvironment hostingEnvironment;
    public FileService(FileRepository<Entities.Models.File> filesRepository, IMapper mapper, IHostingEnvironment _hosting)
    {
        this.filesRepository = filesRepository;
        this.mapper = mapper;
        this.hostingEnvironment = _hosting;
    }

    public void DeleteFile(Guid id)
    {
        var fileToDelete = filesRepository.GetById(id);
        if (fileToDelete == null)
        {
            throw new Exception("File not found");
        }

        filesRepository.Delete(fileToDelete);
    }

    public FileModel GetFile(Guid id)
    {
        var file = filesRepository.GetById(id);
        return mapper.Map<FileModel>(file);
    }

    public PageModel<FilePreviewModel> GetFiles(Guid idUser, int limit = 20, int offset = 0)
    {
        var files = filesRepository.GetAll(idUser);
        int totalCount = files.Count();
        var chunk = files.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<FilePreviewModel>()
        {
            Items = mapper.Map<IEnumerable<FilePreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public FileModel AddFile(Guid idUser, IFormFile file){

        var path = "/Files/" + file.FileName;
        using (var fileStream = new FileStream(hostingEnvironment.WebRootPath + path, FileMode.Create))
        {
            file.CopyToAsync(fileStream);
        }
        FileModel fileModel = new FileModel();

        fileModel.Name = file.Name;
        fileModel.Path =  path;
        fileModel.UserId = idUser;
        fileModel.Extension = file.Name.Substring(file.Name.LastIndexOf("."));

        filesRepository.Save(mapper.Map<Entities.Models.File>(fileModel));
        return fileModel;
    }
}