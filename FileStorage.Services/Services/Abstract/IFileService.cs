using FileStorage.Services.Models;
using Microsoft.AspNetCore.Http;
namespace FileStorage.Services.Abstract;

public interface IFileService
{
    FileModel GetFile(Guid id);

    void DeleteFile(Guid id);

    CreateFileModel AddFile(Guid idUser, IFormFile file);

    PageModel<FilePreviewModel> GetFiles(Guid idUser, int limit = 20, int offset = 0);
}