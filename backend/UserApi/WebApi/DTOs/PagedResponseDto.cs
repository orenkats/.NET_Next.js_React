namespace UserApi.WebApi.DTOs;
public class PagedResponseDto<T>
{
    public IEnumerable<T> Data { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
}
