using Microsoft.EntityFrameworkCore;
using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.DataAccess.Repositories;

public class FloorRepository : BaseRepository<Floor>
{
    private readonly ShivaContext _context;

    public FloorRepository(ShivaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Floor>> GetAllAsync()
    {
        try
        {
            return await _context.floors.Include(u => u.places).ToListAsync();
        }
        catch (Exception msg)
        {
            throw new Exception($"Couldn't load FLOORS from the database : {msg.Message}", msg);
        }
    }
}