using GreenTech.Test.API.UserManagement.Domain.Model.Aggregates;
using GreenTech.Test.API.UserManagement.Domain.Model.ValueObjects;
using GreenTech.Test.API.Shared.Domain.Repositories;

namespace GreenTech.Test.API.UserManagement.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUserIdAsync(UserId userId, CancellationToken cancellationToken = default);
}