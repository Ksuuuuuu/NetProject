using Microsoft.EntityFrameworkCore;
using FileStorage.Entities.Models;

namespace FileStorage.Entities;
public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<File> Files { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        #endregion

        #region Files

        builder.Entity<File>().ToTable("files");
        builder.Entity<File>().HasKey(x => x.Id);
        builder.Entity<File>().HasOne(x => x.User)
                            .WithMany(x => x.Files)
                            .HasForeighKey(x => x.UserId)
                            .OnDelete(DeleteBehavior.Cascade);
        #endregion
    }
}