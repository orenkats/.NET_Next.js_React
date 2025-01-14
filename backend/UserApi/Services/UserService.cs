using Newtonsoft.Json;
using UserApi.Data.Repositories;
using UserApi.Models;

namespace UserApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly HttpClient _httpClient;

    public UserService(IUserRepository repository, HttpClient httpClient)
    {
        _repository = repository;
        _httpClient = httpClient;
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
        var response = await _httpClient.GetStringAsync("https://exampleapi.com/api?results=50");
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
