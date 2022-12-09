using FileStorage.Services.Abstract;
using FileStorage.Services.Implementation;
using FileStorage.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace FileStorage.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        //services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IFileService, FileService>();
    }
}