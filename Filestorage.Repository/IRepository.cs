using System.Linq.Expressions;
using FileStorage.Entities.Models;

namespace FileStorage.Repository;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(Guid UserId);
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    T GetById(Guid id);
    T Save(T obj);
    void Delete(T obj);
}
