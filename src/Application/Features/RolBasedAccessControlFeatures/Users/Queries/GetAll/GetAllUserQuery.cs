using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;
using IMFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetAll;

public class GetAllUserQuery : IRequest<List<GetAllResponseDto>>,ILoggableRequest
{
}

public class GetAllUserQuertyHandler : IRequestHandler<GetAllUserQuery, List<GetAllResponseDto>>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public GetAllUserQuertyHandler(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<List<GetAllResponseDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        List<User> users = await _userManager.Users.ToListAsync(cancellationToken);

        List<GetAllResponseDto> response = _mapper.Map<List<GetAllResponseDto>>(users);
        return response;

    }
}
