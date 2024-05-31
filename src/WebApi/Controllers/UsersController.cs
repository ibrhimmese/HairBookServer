using Application.Features.RolBasedAccessControlFeatures.Users.Commands.Delete;
using Application.Features.RolBasedAccessControlFeatures.Users.Commands.Update;
using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetAll;
using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetById;
using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetListToPaginate;
using Application.Services.Repositories.RolBasedAccessControlRepositories.RoleAttributes;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : BaseController
{
    //[RoleFilter("Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        List<GetAllResponseDto> response = await Mediator!.Send(new GetAllUserQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(int pageNumber = 1, int pageSize = 10)
    {
        var paginationParams = new PaginationParams { PageNumber = pageNumber, PageSize = pageSize };
        var result = await Mediator!.Send(new GetListPagedUsersQuery(paginationParams));
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] GetByUserIdQuery request, CancellationToken cancellationToken)
    {
        GetByIdResponseDto response = await Mediator!.Send(request);
        return Ok(response);
    }

    //[RoleFilter("Admin")]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request);
        return Ok(response);

    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request);
        return Ok(response);

    }

    [HttpGet]
    public IActionResult GetUserInfo()
    {
        var userName = HttpContext.User.Identity?.Name;
        return Ok(new { UserName = userName });
    }


    //[HttpGet]
    //public IActionResult GetClaims()
    //{
    //    var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
    //    return Ok(claims);
    //}

    //[HttpGet("user-info")]
    //public IActionResult GetUserInfo2()
    //{
    //    var userName = HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value
    //                ?? HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.UniqueName)?.Value;
    //    return Ok(new { UserName = userName });
    //}


    //[HttpGet("user-info-manual")]
    //public IActionResult GetUserInfoManual()
    //{
    //    var userName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    //    return Ok(new { UserName = userName });
    //}


}
