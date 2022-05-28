using System.Net;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShivaReborn.DataAccess.Models;

namespace ShivaReborn.DataAccess.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly ShivaContext _context;

    public UserRepository(ShivaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        try
        {
            return await _context.users.ToListAsync();
        }
        catch (Exception msg)
        {
            throw new Exception($"Couldn't load USERS from the database : {msg.Message}", msg);
        }
    }

    public async Task<User> RemoveAsync(int id)
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

    public async Task<User> GetAsync(int id)
    {
        var user = await _context.Set<User>().FirstOrDefaultAsync(t => t.Id == id);
        if (user is null)
        {
            throw new Exception($"Couldn't find in the database the user with id : {id}");
        }

        return user;
    }

    public async Task<User> AddAsync(User user)
    {
        _context.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    
}