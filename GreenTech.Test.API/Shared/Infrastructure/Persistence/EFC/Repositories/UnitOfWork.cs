using GreenTech.Test.API.Shared.Domain.Repositories;
using GreenTech.Test.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace GreenTech.Test.API.Shared.Infrastructure.Persistence.EFC.Repositories;


public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync(CancellationToken cancellationToken = default)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}