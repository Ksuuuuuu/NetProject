using System.Linq.Expressions;
using FileStorage.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FileStorage.Repository;

public class FileRepository<T> : Repository<T> where T : FileStorage.Entities.Models.File
{

    private DbContext _context;
    public FileRepository(DbContext context, ILogger<Repository<T>> logger) : base(context, logger)
    {
        _context = context;
    }

    public IQueryable<T> GetAll(Guid UserId)
    {
        return _context.Set<T>()
        .Where<T>(f => f.UserId == UserId);
    }
}