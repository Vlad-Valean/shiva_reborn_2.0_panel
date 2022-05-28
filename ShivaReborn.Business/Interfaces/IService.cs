using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.Business.Interfaces;

public interface IService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> RemoveAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> GetAsync(int id);
}