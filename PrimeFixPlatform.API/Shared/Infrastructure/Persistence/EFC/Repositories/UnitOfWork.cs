using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Unit of Work implementation for managing transactions
/// </summary>
/// <remarks>
///     This class implements the basic operations for a unit of work.
///     It requires the context to be passed in the constructor.
/// </remarks>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}