using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetListToPaginate;

public class GetListPagedUsersQuery : IRequest<PaginateUserDto>
{
    public PaginationParams PaginationParams { get; set; }
    public GetListPagedUsersQuery(PaginationParams paginationParams)
    {
        PaginationParams = paginationParams;
    }
}

public class GetListPagedUsersQueryHandler : IRequestHandler<GetListPagedUsersQuery, PaginateUserDto>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public GetListPagedUsersQueryHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<PaginateUserDto> Handle(GetListPagedUsersQuery request, CancellationToken cancellationToken)
    {
        var usersQuery = _userManager.Users;
        var totalCount = await usersQuery.CountAsync(cancellationToken);

        var users = await usersQuery
           .Skip((request.PaginationParams.PageNumber - 1) * request.PaginationParams.PageSize)
           .Take(request.PaginationParams.PageSize)
           .ToListAsync(cancellationToken);

        var userDtos = _mapper.Map<List<UserPagedResponseDto>>(users);

        var totalPages = (int)Math.Ceiling(totalCount / (double)request.PaginationParams.PageSize);
        var hasPreviousPage = request.PaginationParams.PageNumber > 1;
        var hasNextPage = request.PaginationParams.PageNumber < totalPages;

        return new PaginateUserDto
        {
            Users = userDtos,
            TotalCount = totalCount,
            PageNumber = request.PaginationParams.PageNumber,
            PageSize = request.PaginationParams.PageSize,
            TotalPages = totalPages,
            HasPreviousPage = hasPreviousPage,
            HasNextPage = hasNextPage
        };
    }
}
