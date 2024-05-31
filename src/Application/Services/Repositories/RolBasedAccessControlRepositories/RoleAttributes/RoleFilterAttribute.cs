using Microsoft.AspNetCore.Mvc;

namespace Application.Services.Repositories.RolBasedAccessControlRepositories.RoleAttributes;

public sealed class RoleFilterAttribute : TypeFilterAttribute
{
    public RoleFilterAttribute(params string[] roles) : base(typeof(RoleFilter))
    {
        Arguments = new object[] { roles };
    }
}
