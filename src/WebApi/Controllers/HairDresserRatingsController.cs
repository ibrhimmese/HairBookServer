using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Delete;
using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Queries.GetAll;
using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairDressersFeatures.Queries.GetAll;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HairDresserRatingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHairDresserRatingCommand request, CancellationToken cancellationToken)
    {
        CreatedHairDresserRatingResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteHairDresserRatingCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        List<GetAllHairDresserRatingResponse> response = await Mediator!.Send(new GetAllHairDresserRatingQuery(),cancellationToken);
        return Ok(response);
    }
}