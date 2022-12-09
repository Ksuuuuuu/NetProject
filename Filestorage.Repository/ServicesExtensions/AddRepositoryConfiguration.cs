using FileStorage.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FileStorage.Repository;

public static partial class ServicesExtensions
{
    public static void AddRepositoryConfiguration(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}