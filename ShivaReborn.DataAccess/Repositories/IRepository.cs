namespace ShivaReborn.DataAccess.Repositories;

public interface IRepository<TEntity> where  TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> RemoveAsync(int id);
    Task<TEntity> GetAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
}