
namespace UserApi.Application.DTOs
{
    public class PaginatedResponseDto<T>
    {
        public IEnumerable<T> Results { get; set; }
        public PaginationInfoDto Info { get; set; }
    }

    public class PaginationInfoDto
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
