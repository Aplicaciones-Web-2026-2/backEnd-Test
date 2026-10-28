using GreenTech.Test.API.IAM.Domain.Model.Aggregates;
using GreenTech.Test.API.IAM.Domain.Model.ValueObjects;
using GreenTech.Test.API.IAM.Domain.Repositories;
using GreenTech.Test.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using GreenTech.Test.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GreenTech.Test.API.IAM.Infrastructure.Persistence;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByUserIdAsync(UserId userId, CancellationToken cancellationToken = default)
    {
        return await Context.Set<User>()
            .FirstOrDefaultAsync(f => f.UserId == userId, cancellationToken);
    }
}