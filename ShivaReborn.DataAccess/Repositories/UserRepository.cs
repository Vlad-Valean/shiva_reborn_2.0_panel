using Microsoft.EntityFrameworkCore;
using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.DataAccess.Repositories;

public class UserRepository : BaseRepository<User>
{
    private readonly ShivaContext _context;

    public UserRepository(ShivaContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<IEnumerable<User>> GetAllAsync()
    {
        try
        {
            return await _context.Set<User>().ToListAsync();
        }
        catch (Exception msg)
        {
            throw new Exception($"Couldn't load USERS from the database : {msg.Message}", msg);
        }
    }
}