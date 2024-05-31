using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Update;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetById;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetList;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetList;
using Application.Features.RolBasedAccessControlFeatures.Users.Queries.GetById;
using IMFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HairDressersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHairDresserCommand request, CancellationToken cancellationToken)
    {
        CreatedHairDresserResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteHairDresserCommand request, CancellationToken cancellationToken)
    {
        DeletedHairDresserResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateHairDresserCommand request, CancellationToken cancellationToken)
    {
        UpdatedHairDresserResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
    {
        GetListHairDressersQuery query = new() { PageRequest = pageRequest };
        GetListResponse<GetListHairDressersListItemDto> response = await Mediator!.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] GetByIdHairDresserQuery request, CancellationToken cancellationToken)
    {
        GetByIdHairDresserResponse response = await Mediator!.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        List<GetAllHairDresserQueryResponse> response = await Mediator!.Send(new GetAllHairDresserQuery(), cancellationToken);
        return Ok(response);
    }
}