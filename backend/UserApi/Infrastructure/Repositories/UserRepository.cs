using Microsoft.EntityFrameworkCore;
using UserApi.Infrastructure.DbContexts;
using UserApi.Application.Interfaces;
using UserApi.Domain.Entities;

namespace UserApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to fetch a paginated list of users
        public async Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize)
        {
            return await _context.Users
                .OrderBy(u => u.FirstName) // Ensure consistent ordering
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        // Method to fetch a user by ID
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Method to search for users by name
        public async Task<IEnumerable<User>> SearchUsersAsync(string query)
        {
            return await _context.Users
                .Where(u => u.FirstName.Contains(query) || u.LastName.Contains(query))
                .ToListAsync();
        }

        // Method to save a batch of users to the database
        public async Task SaveUsersAsync(IEnumerable<User> users)
        {
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        // Method to get the total number of users in the database
        public async Task<int> GetTotalUserCountAsync()
        {
            return await _context.Users.CountAsync();
        }
    }
}
