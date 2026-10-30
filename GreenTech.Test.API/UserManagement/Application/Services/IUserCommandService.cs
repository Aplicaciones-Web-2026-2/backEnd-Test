using GreenTech.Test.API.UserManagement.Application.Errors;
using GreenTech.Test.API.UserManagement.Domain.Model.Aggregates;
using GreenTech.Test.API.UserManagement.Domain.Model.Commands;
using GreenTech.Test.API.Shared.Application.Patterns;

namespace GreenTech.Test.API.UserManagement.Application.Services;

public interface IUserCommandService
{
    Task<Result<User, CreateUserError>> Handle(CreateUserCommand command, CancellationToken cancellationToken = default);
}