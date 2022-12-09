namespace FileStorage.AppConfiguration.ApplicationExtensions
{
    public static partial class AppExtensions
    {
        /// <summary>
        /// authorization configuration
        /// </summary>
        /// <param name="app"></param>
        public static void UseAuthorizationConfiguration(this IApplicationBuilder app)
        {
            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}