using Microsoft.EntityFrameworkCore.Storage;
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
    /// <summary>
    ///     Commit all changes to the database
    /// </summary>
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }

    /// <summary>
    ///     Begin a new transaction
    /// </summary>
    /// <returns>
    ///     A task representing the asynchronous operation, containing the database transaction.
    /// </returns>
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        // No implementation needed for EF Core as it manages transactions automatically
        return await context.Database.BeginTransactionAsync();
    }
}