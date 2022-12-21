using System;
using FileStorage.Entities.Models;
using FileStorage.Repository;
using FileStorage.Services.Abstract;
using Microsoft.AspNetCore.Identity;

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

    public static async Task InitializeRepository(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
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