using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.Business.Interfaces;

public interface IService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> RemoveAsync(string id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> GetAsync(string id);
}