using Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;
using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RolBasedAccessControlFeatures.UserRoles.Queries.GetAll;

public class GetAllUserRolesQuery:IRequest<List<GetAllUserRolesResponse>>
{
}


internal sealed class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, List<GetAllUserRolesResponse>>
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IMapper _mapper;

    public GetAllUserRolesQueryHandler(IUserRoleRepository userRoleRepository, IMapper mapper)
    {
        _userRoleRepository = userRoleRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllUserRolesResponse>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
    {
        List<UserRole> userRoles = await _userRoleRepository.GetAllNoPaginateAsync(
            include:p=>p.Include(p=>p.User!).Include(p=>p.Role!)
            );
        List<GetAllUserRolesResponse> response = _mapper.Map<List<GetAllUserRolesResponse>>(userRoles);

        return response;
    }
}
