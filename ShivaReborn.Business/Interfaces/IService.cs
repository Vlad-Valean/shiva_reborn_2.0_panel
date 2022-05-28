using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.Business.Interfaces;

public interface IService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
}