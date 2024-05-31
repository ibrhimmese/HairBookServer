using Application.Features.ProjectFeatures.HairDresserRatingsFeatures.Commands.Create;
using Application.Features.ProjectFeatures.ServiceRatingsFeatures.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("api/[controller]/[action]")]
[ApiController]
public class ServiceRatingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceRatingCommand request, CancellationToken cancellationToken)
    {
        CreatedServiceRatingResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }
}
