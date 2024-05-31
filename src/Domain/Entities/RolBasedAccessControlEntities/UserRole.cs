
using IMFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.RolBasedAccessControlEntities;

public sealed class UserRole:Entity<Guid>
{
    [ForeignKey("User")]
    public string UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public Role? Role { get; set; }

    public UserRole()
    {
        UserId = string.Empty;
        RoleId = string.Empty;
    }

    public UserRole(string userId, string roleId)
    {
        UserId =userId;
        RoleId =roleId;
    }
}
