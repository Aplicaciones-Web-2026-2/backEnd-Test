using GreenTech.Test.API.IAM.Domain.Model.Aggregates;
using GreenTech.Test.API.IAM.Domain.Model.ValueObjects;
using GreenTech.Test.API.Shared.Domain.Repositories;

namespace GreenTech.Test.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUserIdAsync(UserId userId, CancellationToken cancellationToken = default);
}