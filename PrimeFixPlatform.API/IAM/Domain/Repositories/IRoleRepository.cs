using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.Iam.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing Role entities.
/// </summary>
public interface IRoleRepository : IBaseRepository<Role>
{
    /// <summary>
    ///     Checks if a role exists by its unique identifier.
    /// </summary>
    /// <param name="idRole">
    ///     The unique identifier of the role.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a role with the specified ID exists.
    /// </returns>
    Task<bool> ExitsByIdRole(int idRole);
    
    /// <summary>
    ///     Checks if a role exists by its role information.
    /// </summary>
    /// <param name="roleInformation">
    ///     The role information to check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a role with the specified role information exists.
    /// </returns>
    Task<bool> ExistsByRoleInformation(RoleInformation roleInformation);
    
    /// <summary>
    ///     Checks if a role exists by its role information, excluding a specific role by its ID.
    /// </summary>
    /// <param name="roleInformation">
    ///     The role information to check.
    /// </param>
    /// <param name="idRole">
    ///     The unique identifier of the role to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a role with the specified role information exists,
    ///     excluding the role with the specified ID.
    /// </returns>
    Task<bool> ExistsByRoleInformationAndIdRoleIsNot(RoleInformation roleInformation, int idRole);
}