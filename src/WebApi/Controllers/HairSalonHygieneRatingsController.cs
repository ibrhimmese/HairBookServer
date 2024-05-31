using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairSalonHygieneRatingFeatures.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("api/[controller]/[action]")]
[ApiController]
public class HairSalonHygieneRatingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHairSalonHygieneRatingCommand request, CancellationToken cancellationToken)
    {
        CreateHairSalonHygieneRatingCommandResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }
}