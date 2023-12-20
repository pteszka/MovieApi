using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Repository.Interfaces;

namespace MovieApi.Repository;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    
    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserById(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }


    public async Task DeleteUser(Guid id)
    {
        var user = await GetUserById(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public bool UserExists(Guid id)
    {
        return _context.Users.Any(e => e.UserId == id);
    }
}
