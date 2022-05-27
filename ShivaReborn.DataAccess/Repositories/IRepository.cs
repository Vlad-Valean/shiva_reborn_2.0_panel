namespace ShivaReborn.DataAccess.Repositories;

public interface IRepository<TEntity> where  TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
}