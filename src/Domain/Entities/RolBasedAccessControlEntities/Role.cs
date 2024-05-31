using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.RolBasedAccessControlEntities;

public sealed class Role:IdentityRole<string>
{
    public Role()
    {
        Id=Guid.NewGuid().ToString();
    }
   
}
