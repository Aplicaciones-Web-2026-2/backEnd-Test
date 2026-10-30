using GreenTech.Test.API.UserManagement.Domain.Model.Aggregates;
using GreenTech.Test.API.UserManagement.Domain.Model.Queries;

namespace GreenTech.Test.API.UserManagement.Application.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByUserIdQuery query, CancellationToken cancellationToken = default);
}