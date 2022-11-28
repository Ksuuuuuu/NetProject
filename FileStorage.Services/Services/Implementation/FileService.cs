using AutoMapper;
using FileStorage.Entities.Models;
using FileStorage.Repository;
using FileStorage.Services.Abstract;
using FileStorage.Services.Models;

namespace FileStorage.Services.Implementation;

public class FileService : IFileService
{
    private readonly IRepository<Entities.Models.File> filesRepository;
    private readonly IMapper mapper;
    public FileService(IRepository<Entities.Models.File> filesRepository, IMapper mapper)
    {
        this.filesRepository = filesRepository;
        this.mapper = mapper;
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

    public PageModel<FilePreviewModel> GetFiles(int limit = 20, int offset = 0)
    {
        var files = filesRepository.GetAll();
        int totalCount = files.Count();
        var chunk = files.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<FilePreviewModel>()
        {
            Items = mapper.Map<IEnumerable<FilePreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public FileModel AddFile(FileModel fileModel){
        filesRepository.Save(mapper.Map<Entities.Models.File>(fileModel));
        return fileModel;
    }
}