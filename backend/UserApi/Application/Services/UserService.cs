using Newtonsoft.Json;
using UserApi.Infrastructure.Repositories;
using UserApi.Application.Interfaces;
using UserApi.Domain.Entities;
using UserApi.Domain.Models;

namespace UserApi.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly HttpClient _httpClient;
    private readonly string? _apiUrl;

    public UserService(IUserRepository repository, HttpClient httpClient, IConfiguration configuration)
    {
        _repository = repository;
        _httpClient = httpClient;
        _apiUrl = configuration["ExternalApi:RandomUserUrl"];
    }

    public async Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize)
    {
        return await _repository.GetUsersAsync(page, pageSize);
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _repository.GetUserByIdAsync(id);
    }

    public async Task<IEnumerable<User>> SearchUsersAsync(string query)
    {
        return await _repository.SearchUsersAsync(query);
    }

    public async Task SyncUsersWithApiAsync()
    {
        var response = await _httpClient.GetStringAsync(_apiUrl);
        var apiResponse = JsonConvert.DeserializeObject<UserApiResponse>(response);

        if (apiResponse?.Results == null) return;

        var users = apiResponse.Results.Select(apiUser => new User
        {
            Id = Guid.NewGuid(),
            FirstName = apiUser.Name.First,
            LastName = apiUser.Name.Last,
            Email = apiUser.Email,
            DateOfBirth = DateTime.Parse(apiUser.Dob.Date),
            Phone = apiUser.Phone,
            Address = $"{apiUser.Location.City}, {apiUser.Location.State}",
            ProfilePicture = apiUser.Picture.Large
        });

        await _repository.SaveUsersAsync(users);
    }
}
