namespace MagicVilla_VillaAPI.Repository.IRepository;

using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task RemoveAsync(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true, string? includeProperties = null);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
    Task SaveAsync();
}