using UserApi.Domain.Entities;

namespace UserApi.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize);
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> SearchUsersAsync(string query);
    Task SyncUsersWithApiAsync();
}
