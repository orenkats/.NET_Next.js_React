using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize)
    {
        return await _context.Users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> SearchUsersAsync(string query)
    {
        return await _context.Users
            .Where(u => u.FirstName.Contains(query) || u.LastName.Contains(query))
            .ToListAsync();
    }

    public async Task SaveUsersAsync(IEnumerable<User> users)
    {
        await _context.Users.AddRangeAsync(users);
        await _context.SaveChangesAsync();
    }
}
