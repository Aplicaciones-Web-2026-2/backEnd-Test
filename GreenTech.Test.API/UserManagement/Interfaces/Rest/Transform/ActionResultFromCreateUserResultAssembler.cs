using GreenTech.Test.API.Resources;
using GreenTech.Test.API.Shared.Application.Patterns;
using GreenTech.Test.API.UserManagement.Application.Errors;
using GreenTech.Test.API.UserManagement.Domain.Model.Aggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace GreenTech.Test.API.UserManagement.Interfaces.Rest.Transform;

public static class ActionResultFromCreateUserResultAssembler
{
    public static ActionResult ToActionResultFromCreateUserResult(
        Result<User, CreateUserError> result,
        ControllerBase controller,
        IStringLocalizer<SharedResource> localizer,
        string createdLocationTemplate) =>
        result switch
        {
            Result<User, CreateUserError>.Success success =>
                controller.Created(string.Format(createdLocationTemplate, success.Value.Id),
                    UserResourceFromEntityAssembler.ToResourceFromEntity(success.Value)),

            Result<User, CreateUserError>.Failure failure =>
                failure.Error switch
                {
                    CreateUserError.DuplicatedUser =>
                        controller.Conflict(localizer["UserManagementUserDuplicated"].Value),

                    CreateUserError.UnexpectedError =>
                        controller.Problem(
                            title: localizer["UserManagementUserUnexpectedError"].Value,
                            detail: localizer["UserManagementUserUnexpectedError"].Value,
                            statusCode: 500),
                    _ => controller.Problem(
                        title: localizer["UnexpectedServerError"].Value,
                        detail: localizer["UnexpectedErrorProcessingRequest"].Value,
                        statusCode: 500)
                },
            _ => controller.Problem(
                title: localizer["UnexpectedServerError"].Value,
                detail: localizer["UnexpectedErrorProcessingRequest"].Value,
                statusCode: 500)
        };
}