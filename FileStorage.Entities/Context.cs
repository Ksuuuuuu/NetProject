using Microsoft.EntityFrameworkCore;
using FileStorage.Entities.Models;

namespace FileStorage.Entities;
public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Models.File> Files { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

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