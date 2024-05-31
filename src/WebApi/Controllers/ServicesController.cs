using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Update;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetById;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetList;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.ServicesFeatures.Commands.Create;
using Application.Features.ProjectFeatures.ServicesFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.ServicesFeatures.Commands.Update;
using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetById;
using Application.Features.ProjectFeatures.ServicesFeatures.Queries.GetList;
using IMFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ServicesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceCommand request, CancellationToken cancellationToken)
    {
        CreatedServiceResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        DeletedServiceCommandResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        UpdatedServiceCommandResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
    {
        GetListServicesQuery query = new() { PageRequest = pageRequest };
        GetListResponse<GetListServicesListItemDto> response = await Mediator!.Send(query, cancellationToken);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        List<GetAllServicesResponse> response = await Mediator!.Send(new GetAllServicesQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] GetByIdServiceQuery request, CancellationToken cancellationToken)
    {
        GetByIdServiceResponse response = await Mediator!.Send(request);
        return Ok(response);
    }
}