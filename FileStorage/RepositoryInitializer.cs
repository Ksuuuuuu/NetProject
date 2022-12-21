using System;
using FileStorage.Entities;
using FileStorage.Entities.Models;
using FileStorage.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FileStorage.AppConfiguration;

public static class RepositoryInitializer
{
    public const string MASTER_ADMIN_LOGIN = "master";
    public const string MASTER_ADMIN_EMAIL = "master@";
    public const string MASTER_ADMIN_PASSWORD = "master";

    private static async Task CreateGlobalAdmin(IAuthService authService)
    {
        await authService.RegisterUser(new Services.Models.RegisterUserModel()
        {
            Login = MASTER_ADMIN_LOGIN,
            Password = MASTER_ADMIN_PASSWORD,
            Email = MASTER_ADMIN_EMAIL
        });
    }

    public static async Task InitializeRepository(IServiceProvider provider)
    {
        using (var scope = provider.GetService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<Context>();            
            context.Database.Migrate();
            
            var userManager = (UserManager<User>)scope.ServiceProvider.GetRequiredService(typeof(UserManager<User>));
            var user = await userManager.FindByNameAsync(MASTER_ADMIN_LOGIN);
            if (user == null)
            {
                var authService = (IAuthService)scope.ServiceProvider.GetRequiredService(typeof(IAuthService));
                await CreateGlobalAdmin(authService);
            }
        }
    }
}