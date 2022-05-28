namespace ShivaReborn.DataAccess.Repositories;

public interface IRepository<TEntity> where  TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> RemoveAsync(string id);
    Task<TEntity> GetAsync(string id);
    Task<TEntity> AddAsync(TEntity entity);
}