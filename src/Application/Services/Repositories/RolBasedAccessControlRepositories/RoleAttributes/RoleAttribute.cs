using Application.Services.Repositories.RolBasedAccessControlRepositories.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Repositories.RolBasedAccessControlRepositories.RoleAttributes;

public class RoleFilter : IAsyncAuthorizationFilter
{
    private readonly string[] _roles;
    private readonly IUserRoleRepository _userRoleRepository;

    public RoleFilter(string[] roles, IUserRoleRepository userRoleRepository)
    {
        _roles = roles;
        _userRoleRepository = userRoleRepository;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            context.Result = new UnauthorizedObjectResult(new { message = "Kullanıcı kimliği bulunamadı. Yetkiniz yok." });
            return;
        }

        if (_userRoleRepository == null)
        {
            context.Result = new ObjectResult(new { message = "Kullanıcı rolü deposu bulunamadı. Yetkiniz yok." })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            return;
        }

        // Kullanıcı rolünü kontrol etmek için predicate oluşturuyoruz
        var userId = userIdClaim.Value;
        var userHasRole = await _userRoleRepository.AnyAsync(
            predicate: p => p.UserId == userId && _roles.Contains(p.Role!.Name),
            include: queryable => queryable.Include(p => p.Role!),
            withDeleted: false
        );

        if (!userHasRole)
        {
            context.Result = new UnauthorizedObjectResult(new { message = "Belirtilen rollerden hiçbirine sahip değilsiniz. Yetkiniz yok." });
            return;
        }
    }
}
