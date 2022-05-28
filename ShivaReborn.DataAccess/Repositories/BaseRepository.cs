using Microsoft.EntityFrameworkCore;
using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
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

        public virtual async Task<TEntity> RemoveAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id == id);
            if (entity is null)
            {
                throw new Exception($"Couldn't find in the database the entity with id : {id}");
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id == id);
            if (entity is null)
            {
                throw new Exception($"Couldn't find in the database the entity with id : {id}");
            }
            return entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
    }
}