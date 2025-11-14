using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing Role entities.
/// </summary>
/// <param name="context">
///     The database context used for data access.
/// </param>
public class RoleRepository(AppDbContext context)
: BaseRepository<Role>(context), IRoleRepository
{
    /// <summary>
    ///     Checks if a Role exists by its unique identifier.
    /// </summary>
    /// <param name="idRole">
    ///     The unique identifier of the Role.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a Role with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExitsByIdRole(string idRole)
    {
        return await Context.Set<Role>().AnyAsync(role => role.IdRole == idRole);
    }

    /// <summary>
    ///     Checks if a Role exists by its RoleInformation.
    /// </summary>
    /// <param name="roleInformation">
    ///     The RoleInformation of the Role.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a Role with the specified RoleInformation exists.
    /// </returns>
    public async Task<bool> ExistsByRoleInformation(RoleInformation roleInformation)
    {
        return await Context.Set<Role>().AnyAsync(role => role.RoleInformation.Name == roleInformation.Name 
                                                          || role.RoleInformation.Description == roleInformation.Description);
    }

    /// <summary>
    ///     Checks if a Role exists by its RoleInformation, excluding a specific role by ID.
    /// </summary>
    /// <param name="roleInformation">
    ///     The RoleInformation of the Role.
    /// </param>
    /// <param name="idRole">
    ///     The unique identifier of the Role to exclude.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a Role with the specified RoleInformation exists,
    ///     excluding the Role with the specified ID.
    /// </returns>
    public async Task<bool> ExistsByRoleInformationAndIdRoleIsNot(RoleInformation roleInformation, string idRole)
    {
        return await Context.Set<Role>().AnyAsync(role => (role.RoleInformation.Name == roleInformation.Name 
                                                           || role.RoleInformation.Description == roleInformation.Description)
                                                          && role.IdRole != idRole);
    }
}