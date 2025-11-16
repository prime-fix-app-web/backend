using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.QueryServices;

/// <summary>
///     Query service for roles
/// </summary>
/// <param name="roleRepository">
///     The role repository
/// </param>
public class RoleQueryService(IRoleRepository roleRepository)
: IRoleQueryService
{
    /// <summary>
    ///     Handles the query to get all roles
    /// </summary>
    /// <param name="query">
    ///     The query to get all roles
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of roles.
    /// </returns>
    public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery query)
    {
        return await roleRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the query to get a role by its unique identifier
    /// </summary>
    /// <param name="query">
    ///     The query to get a role by its unique identifier
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the role if found; otherwise, null.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a role with the specified identifier was not found.
    /// </exception>
    public async Task<Role?> Handle(GetRoleByIdQuery query)
    {
        return await roleRepository.FindByIdAsync(query.IdRole)
            ?? throw new NotFoundIdException("Role with the id " + query.IdRole + " was not found.");
    }
}