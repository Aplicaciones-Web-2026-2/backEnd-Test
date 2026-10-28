namespace GreenTech.Test.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync(CancellationToken cancellationToken = default);
}