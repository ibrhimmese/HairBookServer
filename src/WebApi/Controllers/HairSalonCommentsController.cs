using Application.Features.ProjectFeatures.HairDressersFeatures.Commands.Create;
using Application.Features.ProjectFeatures.HairSalonCommentsFeatures.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HairSalonCommentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHairSalonCommentCommand request, CancellationToken cancellationToken)
    {
        CreatedHairSalonCommentCommandResponse response = await Mediator!.Send(request, cancellationToken);
        return Ok(response);
    }
}

