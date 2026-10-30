using System.Net.Mime;
using GreenTech.Test.API.Resources;
using GreenTech.Test.API.UserManagement.Application.Services;
using GreenTech.Test.API.UserManagement.Domain.Model.Queries;
using GreenTech.Test.API.UserManagement.Domain.Model.ValueObjects;
using GreenTech.Test.API.UserManagement.Interfaces.Rest.Resources;
using GreenTech.Test.API.UserManagement.Interfaces.Rest.Transform;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace GreenTech.Test.API.UserManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Favorite Sources")]
public class UserController(
    IUserCommandService userCommandService,
    IStringLocalizer<SharedResource> localizer,
    ILogger<UserController>  logger,
    IUserQueryService userQueryService)
    : ControllerBase
{
    private const string UserLocationTemplate = "/api/v1/users/{0}";

    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(UserResource), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUserByUserId(UserId userId,
        [FromHeader(Name = "Accept-Language")] string? acceptLanguage, CancellationToken cancellationToken = default)
    {
        var getUserByUserIdQuery = new GetUserByUserIdQuery(userId);
        var result = await userQueryService.Handle(getUserByUserIdQuery, cancellationToken);
        if (result is null) return NotFound();
        var resource = UserResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserResource), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CreatedUser([FromBody] CreateUserResource resource,
        [FromHeader(Name = "Accept-Language")] string? acceptLanguage,
        CancellationToken cancellationToken)
    {
        try
        {
            var createUserCommand =
                CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await userCommandService.Handle(createUserCommand, cancellationToken);
            return ActionResultFromCreateUserResultAssembler.ToActionResultFromCreateUserResult(
                result,
                this,
                localizer,
                UserLocationTemplate);
        }
        catch (ArgumentException ex)
        {
            logger.LogWarning(ex,
                "Validation failed while creating User for UserId {UserId}", resource.UserId);
            return BadRequest(localizer["InvalidUserRequest"].Value);
        }
        catch (Exception ex)
        {
            logger.LogError(ex,
                "Unexpected error while creating User for USerId {UserId}", resource.UserId);
            return Problem(
                title: localizer["UnexpectedServerError"].Value,
                detail: localizer["UnexpectedErrorCreatingUser"].Value,
                statusCode: 500
                );
        }
    }
}