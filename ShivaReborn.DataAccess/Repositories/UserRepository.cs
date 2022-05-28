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

    public override async Task<IEnumerable<User>> GetAllAsync()
    {
        try
        {
<<<<<<< HEAD
            return await _context.users.ToListAsync();
=======
            return await _context.users.Include(u => u.assignedPlace).ToListAsync();
>>>>>>> parent of 41b9311... login done
        }
        catch (Exception msg)
        {
            throw new Exception($"Couldn't load USERS from the database : {msg.Message}", msg);
        }
    }
    public override async Task<User> RemoveAsync(string id)
    {
        var user = await _context.Set<User>().FirstOrDefaultAsync(b => b.Id == id);
        if (user is null)
        {
            throw new Exception($"Couldn't find in the database the user with id : {id}");
        }

        _context.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public override async Task<User> GetAsync(string id)
    {
        var user = await _context.Set<User>().FirstOrDefaultAsync(t => t.Id == id);
        if (user is null)
        {
            throw new Exception($"Couldn't find in the database the user with id : {id}");
        }
        return user;
    }

    public override async Task<User> AddAsync(User user)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
}