using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Delete;
using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Update;
using Application.Features.RolBasedAccessControlFeatures.UserRoles.Commands.Create;
using Application.Features.RolBasedAccessControlFeatures.UserRoles.Commands.Delete;
using Application.Features.RolBasedAccessControlFeatures.UserRoles.Commands.Update;
using Application.Features.RolBasedAccessControlFeatures.UserRoles.Queries.GetAll;
using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetAll;
using Application.Services.Repositories.RolBasedAccessControlRepositories.RoleAttributes;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRolesController : BaseController
    {
        //[RoleFilter("Admin", "Moderator")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await Mediator!.Send(request, cancellationToken);
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            List<GetAllUserRolesResponse> response = await Mediator!.Send(new GetAllUserRolesQuery(), cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await Mediator!.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await Mediator!.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
