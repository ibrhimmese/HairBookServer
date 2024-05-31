using Application.Features.RolBasedAccessControlFeatures.Users.Rules;
using Domain.Entities.RolBasedAccessControlEntities;
using Infrastructure.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.RolBasedAccessControlFeatures.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<MessageResponse>
{
    public string Id { get; set; }
    public DeleteUserCommand(string id)
    {
        Id = id;
    }
}


internal sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, MessageResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly UserBusinessRules _businessRules;

    public DeleteUserCommandHandler(UserManager<User> userManager, UserBusinessRules businessRules)
    {
        _userManager = userManager;
        _businessRules = businessRules;
    }
    public async Task<MessageResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByIdAsync(request.Id);
        if (user is null)
        {
            await _businessRules.UserNotFound(request.Id);
        }
        await _userManager.DeleteAsync(user!);

        return new("Kullanıcı Başarıyla silindi");
    }
}