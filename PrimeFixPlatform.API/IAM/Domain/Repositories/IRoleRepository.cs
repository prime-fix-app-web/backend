using PrimeFixPlatform.API.Iam.Domain.Model.Entities;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.Iam.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing Role entities.
/// </summary>
public interface IRoleRepository : IBaseRepository<Role>
{
    /// <summary>
    ///     Gets a role by its name.
    /// </summary>
    /// <param name="name">
    ///     The name of the role to retrieve.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    /// </returns>
    Task<Role?> GetByNameAsync(ERole name);
    
    /// <summary>
    ///     Checks if a role with the specified name exists.
    /// </summary>
    /// <param name="name">
    ///     The name of the role to check for existence.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     true if a role with the specified name exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsByNameAsync(ERole name);
}