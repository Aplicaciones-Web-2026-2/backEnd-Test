using GreenTech.Test.API.IAM.Domain.Model.Aggregates;
using GreenTech.Test.API.Shared.Domain.Repositories;

namespace GreenTech.Test.API.IAM.Domain.Repositories;

public interface ISubscriptionRepository : IBaseRepository<Subscription>
{
    Task<Subscription> GetSubscriptionByIdAsync(long subscriptionId, CancellationToken cancellationToken = default);
}