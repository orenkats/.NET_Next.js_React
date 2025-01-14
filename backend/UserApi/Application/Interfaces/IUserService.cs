using UserApi.Domain.Entities;
using UserApi.Application.DTOs;
namespace UserApi.Application.Interfaces;

// File: Application/Interfaces/IUserService.cs
public interface IUserService
{
    Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize);
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> SearchUsersAsync(string query);
    Task FetchAndSaveUsersAsync(int count); // Add this method here
    Task<PaginatedResponseDto<UserDto>> GetPaginatedUsersAsync(int page, int pageSize);
}


