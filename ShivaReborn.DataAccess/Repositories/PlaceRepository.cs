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
}