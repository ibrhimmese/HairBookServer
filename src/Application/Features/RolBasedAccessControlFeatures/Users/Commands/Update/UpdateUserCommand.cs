using Application.Features.RolBasedAccessControlFeatures.Users.Rules;
using AutoMapper;
using Domain.Entities.RolBasedAccessControlEntities;
using Infrastructure.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.RolBasedAccessControlFeatures.Users.Commands.Update;

public class UpdateUserCommand:IRequest<MessageResponse>
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserName { get; set; }=string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, MessageResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly UserBusinessRules _businessRules;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(UserManager<User> userManager, UserBusinessRules businessRules, IMapper mapper)
    {
        _userManager = userManager;
        _businessRules = businessRules;
        _mapper = mapper;
    }

    public async Task<MessageResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByIdAsync(request.Id);
        if (user is null)
        {
            await _businessRules.UserNotFound(request.Id);
        }
        else
        {
            _mapper.Map(request, user);
            await _userManager.UpdateAsync(user);
        }
        return new MessageResponse("Kullanıcı Başarıyla Güncellendi");
    }
}
