using Domain.Entities.RolBasedAccessControlEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Features.RolBasedAccessControlFeatures.UserRoles.Queries.GetAll;

public class GetAllUserRolesResponse
{
    public Guid Id { get; set; }
    public string UserId { get; set; }=string.Empty;
    public string UserFullName { get; set; } = string.Empty;
    public string RoleId { get; set; }=string.Empty;
    public string RoleName { get; set; } = string.Empty;
}
