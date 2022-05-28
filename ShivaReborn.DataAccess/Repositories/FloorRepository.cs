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
    public override async Task<Floor> RemoveAsync(string id)
    {
        var floor = await _context.Set<Floor>().FirstOrDefaultAsync(b => b.Id == id);
        if (floor is null)
        {
            throw new Exception($"Couldn't find in the database the floor with id : {id}");
        }

        _context.Remove(floor);
        await _context.SaveChangesAsync();
        return floor;
    }
    public override async Task<Floor> GetAsync(string id)
    {
        var floor = await _context.Set<Floor>().FirstOrDefaultAsync(t => t.Id == id);
        if (floor is null)
        {
            throw new Exception($"Couldn't find in the database the floor with id : {id}");
        }
        return floor;
    }

    public override async Task<Floor> AddAsync(Floor floor)
    {
        _context.Add(floor);
        await _context.SaveChangesAsync();
        return floor;
    }
}