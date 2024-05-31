using Application.Features.ProjectFeatures.HairSalonImagesFeatures;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Commands.Update;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetById;
using Application.Features.ProjectFeatures.HairSalonsFeatures.Queries.GetList;
using IMFrameworkCore;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HairSalonsController:BaseController
{

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHairSalonCommand createHairSalonCommand, CancellationToken cancellationToken)
    {
        CreatedHairSalonResponse createdHairSalonResponse = await Mediator!.Send(createHairSalonCommand, cancellationToken);
        return Ok(createdHairSalonResponse);
    }
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, CancellationToken cancellationToken)
    {
      GetListHairSalonQuery getListHairSalonQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListHairSalonListItemDto> response = await Mediator!.Send(getListHairSalonQuery, cancellationToken);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteHairSalonCommand deleteHairSalonCommand, CancellationToken cancellationToken)
    {
        DeletedHairSalonCommandResponse deletedHairSalonResponse = await Mediator!.Send(deleteHairSalonCommand, cancellationToken);
        return Ok(deletedHairSalonResponse);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateHairSalonCommand request, CancellationToken cancellationToken)
    {
        UpdatedHairSalonResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        List<GetAllHairSalonsResponse> response = await Mediator!.Send(new GetAllHairSalonQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] GetByIdHairSalonQuery request, CancellationToken cancellationToken)
    {
        GetByIdHairSalonResponse response = await Mediator!.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage([FromForm] CreateHairImageCommand command)
    {
        var image = await Mediator!.Send(command);
        return Ok(image);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteImage(Guid id)
    {
       MessageResponse response = await Mediator!.Send(new DeleteHairImageCommand { ImageId = id });
        return Ok(response);
    }


}
