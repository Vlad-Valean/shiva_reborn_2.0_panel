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
            return await _context.buildings.ToListAsync();
        }
        catch (Exception msg)
        {
            throw new Exception($"Couldn't load BUILDINGS from the database : {msg.Message}", msg);
        }
    }
    public override async Task<Building> RemoveAsync(string id)
    {
        var building = await _context.Set<Building>().FirstOrDefaultAsync(b => b.Id == id);
        if (building is null)
        {
            throw new Exception($"Couldn't find in the database the building with id : {id}");
        }

        _context.Remove(building);
        await _context.SaveChangesAsync();
        return building;
    }
    public override async Task<Building> GetAsync(string id)
    {
        var building = await _context.Set<Building>().FirstOrDefaultAsync(t => t.Id == id);
        if (building is null)
        {
            throw new Exception($"Couldn't find in the database the building with id : {id}");
        }
        return building;
    }

    public override async Task<Building> AddAsync(Building building)
    {
        _context.Add(building);
        await _context.SaveChangesAsync();
        return building;
    }
}