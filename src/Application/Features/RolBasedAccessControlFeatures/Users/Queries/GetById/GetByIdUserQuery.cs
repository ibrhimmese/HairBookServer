using Application.Features.RolBasedAccessControlFeatures.Users.Rules;
using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetById;

public class GetByUserIdQuery : IRequest<GetByIdResponseDto>
{
    public string Id { get; set; }=string.Empty;
}


public sealed class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, GetByIdResponseDto>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _businessRules;

    public GetByUserIdQueryHandler(UserManager<User> userManager, IMapper mapper, UserBusinessRules businessRules)
    {
        _userManager = userManager;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<GetByIdResponseDto> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByIdAsync(request.Id);
        if (user is null)
        {
            await _businessRules.UserNotFound(request.Id);

        }
        GetByIdResponseDto response = _mapper.Map<GetByIdResponseDto>(user);
        return response;
    }
}

