using Microsoft.EntityFrameworkCore;

namespace ShivaReborn.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ShivaContext _context;

        public BaseRepository(ShivaContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception msg)
            {
                throw new Exception($"Couldn't load from the database : {msg.Message}", msg);
            }
        }
    }
}