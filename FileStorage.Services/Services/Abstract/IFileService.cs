using FileStorage.Services.Models;

namespace FileStorage.Services.Abstract;

public interface IFileService
{
    FileModel GetFile(Guid id);

    void DeleteFile(Guid id);

    FileModel AddFile(FileModel fileModel);

    PageModel<FilePreviewModel> GetFiles(int limit = 20, int offset = 0);
}