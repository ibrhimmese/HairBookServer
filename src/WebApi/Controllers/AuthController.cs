using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangeEmail;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangePassword;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.ChangePasswordAdmin;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.CreateRefreshToken;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Login;
using Application.Features.RolBasedAccessControlFeatures.Auth.Commands.Register;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class AuthController : BaseController
{


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request);
        return Ok(response);

    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await Mediator!.Send(request);
        return Ok(response);

    }

    [HttpPost]
    public async Task<IActionResult> CreateRefreshToken([FromBody] CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await Mediator!.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> ChangePasswordUseAdmin([FromBody] ChangePasswordAdminCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await Mediator!.Send(request);
        return Ok(response);
    }
}
