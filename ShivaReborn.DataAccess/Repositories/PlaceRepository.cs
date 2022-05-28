using Microsoft.EntityFrameworkCore;
using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.DataAccess.Repositories;

public class PlaceRepository : BaseRepository<Place>
{
    private readonly ShivaContext _context;

    public PlaceRepository(ShivaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Place>> GetAllAsync()
    {
        try
        {
            return await _context.places.ToListAsync();
        }
        catch (Exception msg)
        {
            throw new Exception($"Couldn't load PLACES from the database : {msg.Message}", msg);
        }
    }
    public override async Task<Place> RemoveAsync(int id)
    {
        var place = await _context.Set<Place>().FirstOrDefaultAsync(b => b.Id == id);
        if (place is null)
        {
            throw new Exception($"Couldn't find in the database the place with id : {id}");
        }

        _context.Remove(place);
        await _context.SaveChangesAsync();
        return place;
    }
    public override async Task<Place> GetAsync(int id)
    {
        var place = await _context.Set<Place>().FirstOrDefaultAsync(t => t.Id == id);
        if (place is null)
        {
            throw new Exception($"Couldn't find in the database the place with id : {id}");
        }
        return place;
    }

    public override async Task<Place> AddAsync(Place place)
    {
        _context.Add(place);
        await _context.SaveChangesAsync();
        return place;
    }
}