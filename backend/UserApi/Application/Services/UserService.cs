using Newtonsoft.Json;
using UserApi.Application.Interfaces;
using UserApi.Application.DTOs;
using UserApi.Domain.Entities;
using UserApi.Domain.Models;

namespace UserApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly HttpClient _httpClient;
        private readonly string? _apiUrl;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository repository, HttpClient httpClient, IConfiguration configuration, ILogger<UserService> logger)
        {
            _repository = repository;
            _httpClient = httpClient;
            _apiUrl = configuration["ExternalApi:RandomUserUrl"];
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(int page, int pageSize)
        {
            
            var totalUserCount = await _repository.GetTotalUserCountAsync();
    
            // Check if external API fetch is needed
            if (totalUserCount == 0 || (page - 1) * pageSize >= totalUserCount)
            {
                await FetchAndSaveUsersAsync(20);
            }

            var users = await _repository.GetUsersAsync(page, pageSize);

            return users;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _repository.GetUserByIdAsync(id);
        }

        public async Task<IEnumerable<User>> SearchUsersAsync(string query)
        {
            return await _repository.SearchUsersAsync(query);
        }

        public async Task FetchAndSaveUsersAsync(int count)
        {
        
            var response = await _httpClient.GetStringAsync($"{_apiUrl}?results={count}");
            var apiResponse = JsonConvert.DeserializeObject<UserApiResponse>(response);

            if (apiResponse?.Results == null || !apiResponse.Results.Any())
            {
                return;
            }

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
            }).ToList();

            await _repository.SaveUsersAsync(users);
           
        }

        public async Task<PaginatedResponseDto<UserDto>> GetPaginatedUsersAsync(int page, int pageSize)
        {
        
            // Use this.GetUsersAsync to avoid circular dependency
            var users = await GetUsersAsync(page, pageSize);
            var totalCount = await _repository.GetTotalUserCountAsync();

            return new PaginatedResponseDto<UserDto>
            {
                Results = users.Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    DateOfBirth = u.DateOfBirth ?? DateTime.MinValue,
                    Phone = u.Phone,
                    Address = u.Address,
                    ProfilePicture = u.ProfilePicture
                }),
                Info = new PaginationInfoDto
                {
                    TotalCount = totalCount,
                    Page = page,
                    PageSize = pageSize
                }
            };
        }
    }
}
