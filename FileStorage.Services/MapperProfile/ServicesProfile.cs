using AutoMapper;
using FileStorage.Entities.Models;
using FileStorage.Services.Models;

namespace FileStorage.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>().ReverseMap();
        CreateMap<User, UpdateUserModel>().ReverseMap();

        #endregion

        #region Files

        CreateMap<Entities.Models.File, FileModel>().ReverseMap();
        CreateMap<Entities.Models.File, FilePreviewModel>().ReverseMap();

        #endregion
    }
}