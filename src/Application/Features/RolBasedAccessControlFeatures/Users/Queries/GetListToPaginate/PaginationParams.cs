namespace Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetListToPaginate;

public class PaginationParams
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
