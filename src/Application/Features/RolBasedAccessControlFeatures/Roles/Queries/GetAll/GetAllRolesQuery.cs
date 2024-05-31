using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetAll;
using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;
using IMFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RolBasedAccessControlFeatures.Roles.Queries.GetAll;

public class GetAllRolesQuery : IRequest<List<GetAllRolesDto>>, ILoggableRequest
{
}

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<GetAllRolesDto>>
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public GetAllRolesQueryHandler(RoleManager<Role> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<List<GetAllRolesDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        List<Role> users = await _roleManager.Roles.ToListAsync(cancellationToken);

        List<GetAllRolesDto> response = _mapper.Map<List<GetAllRolesDto>>(users);
        return response;

    }
}
