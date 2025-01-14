using UserApi.Domain.Entities;

namespace UserApi.Application.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize);
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> SearchUsersAsync(string query);
    Task<int> GetTotalUserCountAsync();
    Task SaveUsersAsync(IEnumerable<User> users);
}
