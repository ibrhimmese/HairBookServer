namespace Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetListToPaginate;

public class PaginateUserDto
{
    public List<UserPagedResponseDto>? Users { get; set; }
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}
