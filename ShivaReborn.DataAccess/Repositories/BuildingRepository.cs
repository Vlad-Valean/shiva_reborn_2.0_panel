using Microsoft.EntityFrameworkCore;
using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.DataAccess.Repositories;

public class BuildingRepository : BaseRepository<Building>
{
    private readonly ShivaContext _context;

    public BuildingRepository(ShivaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Building>> GetAllAsync()
    {
        try
        {
            return await _context.buildings.Include(u => u.floors).ToListAsync();
        }
        catch (Exception msg)
        {
            throw new Exception($"Couldn't load BUILDINGS from the database : {msg.Message}", msg);
        }
    }
}