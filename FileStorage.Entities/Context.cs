using Microsoft.EntityFrameworkCore;
using FileStorage.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FileStorage.Entities;
public class Context : IdentityDbContext<User, UserRole, Guid>
{
    //public DbSet<User> Users { get; set; }
    //public DbSet<Models.File> Files { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");
        builder.Entity<UserRole>().ToTable("user_roles");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("user_role_claims");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_role_owners");

        #endregion


        #region Files

        builder.Entity<Models.File>().ToTable("files");
        builder.Entity<Models.File>().HasKey(x => x.Id);
        builder.Entity<Models.File>().HasOne(x => x.User)
                                    .WithMany(x => x.Files)
                                    .HasForeignKey(x => x.UserId)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}