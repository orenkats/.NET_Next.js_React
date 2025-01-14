using UserApi.Models;

namespace UserApi.Data.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize);
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> SearchUsersAsync(string query);
    Task SaveUsersAsync(IEnumerable<User> users);
}
