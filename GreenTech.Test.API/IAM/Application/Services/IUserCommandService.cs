using GreenTech.Test.API.IAM.Application.Errors;
using GreenTech.Test.API.IAM.Domain.Model.Aggregates;
using GreenTech.Test.API.IAM.Domain.Model.Commands;
using GreenTech.Test.API.Shared.Application.Patterns;

namespace GreenTech.Test.API.IAM.Application.Services;

public interface IUserCommandService
{
    Task<Result<User, CreateUserError>> Handle(CreateUserCommand command, CancellationToken cancellationToken = default);
}