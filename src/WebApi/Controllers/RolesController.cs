using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Create;
using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Delete;
using Application.Features.RolBasedAccessControlFeatures.Roles.Commands.Update;
using Application.Features.RolBasedAccessControlFeatures.Roles.Queries.GetAll;
using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetAll;
using Application.Services.Repositories.RolBasedAccessControlRepositories.RoleAttributes;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RoleController : BaseController
{

    //[RoleFilter("Admin", "Moderator")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }

    //[RoleFilter("Admin", "Moderator")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        List<GetAllRolesDto> response = await Mediator!.Send(new GetAllRolesQuery(), cancellationToken);
        return Ok(response);
    }
}
