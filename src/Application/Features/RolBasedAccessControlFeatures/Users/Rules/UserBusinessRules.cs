using Domain.Entities.RolBasedAccessControlEntities;
using IMFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.RolBasedAccessControlFeatures.Users.Rules;

public class UserBusinessRules(UserManager<User> userManager) : BaseBusinessRules
{
    public async Task UserNotFound(string id)
    {
        User? user = await userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new BusinessException("Kullanıcı bulunamadı");
        }
    }
}
