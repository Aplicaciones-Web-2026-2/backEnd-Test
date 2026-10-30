using GreenTech.Test.API.UserManagement.Application.Services;
using GreenTech.Test.API.UserManagement.Domain.Model.Aggregates;
using GreenTech.Test.API.UserManagement.Domain.Model.Queries;
using GreenTech.Test.API.UserManagement.Domain.Repositories;

namespace GreenTech.Test.API.UserManagement.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByUserIdQuery query, CancellationToken cancellationToken = default) =>
        await userRepository.FindByUserIdAsync(query.Id, cancellationToken);
}