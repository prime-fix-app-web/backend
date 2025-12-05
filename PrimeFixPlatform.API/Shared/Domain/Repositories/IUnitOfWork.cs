using Microsoft.EntityFrameworkCore.Storage;

namespace PrimeFixPlatform.API.Shared.Domain.Repositories;

/// <summary>
///     Unit of work interface
/// </summary>
/// <remarks>
///     This interface defines the basic operations for a unit of work
/// </remarks>
public interface IUnitOfWork
{
    /// <summary>
    ///     Commit all changes to the database.
    /// </summary>
    /// <returns>
    ///     The task representing the asynchronous operation.
    /// </returns>
    Task CompleteAsync();
    
    /// <summary>
    ///     Begin a new transaction.
    /// </summary>
    /// <returns>
    ///     The task representing the asynchronous operation.
    /// </returns>
    Task<IDbContextTransaction> BeginTransactionAsync();
}