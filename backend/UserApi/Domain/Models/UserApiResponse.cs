namespace UserApi.Domain.Models
{
    public class UserApiResponse
    {
        public List<ApiUser>? Results { get; set; }
    }

    public class ApiUser
    {
        public ApiUserName? Name { get; set; }
        public string? Email { get; set; }
        public ApiUserDob? Dob { get; set; }
        public string? Phone { get; set; }
        public ApiUserLocation? Location { get; set; }
        public ApiUserPicture? Picture { get; set; }
    }

    public class ApiUserName
    {
        public string? Title { get; set; }
        public string? First { get; set; }
        public string? Last { get; set; }
    }

    public class ApiUserDob
    {
        public string? Date { get; set; }
    }

    public class ApiUserLocation
    {
        public string? City { get; set; }
        public string? State { get; set; }
    }

    public class ApiUserPicture
    {
        public string? Large { get; set; }
    }
}
