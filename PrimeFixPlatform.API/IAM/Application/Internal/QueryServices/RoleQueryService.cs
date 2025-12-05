using PrimeFixPlatform.API.Iam.Domain.Model.Entities;
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

    public async Task<Role?> Handle(GetRoleByNameQuery query)
    {
        return await roleRepository.GetByNameAsync(query.Name)
            ?? throw new NotFoundArgumentException("Role with the name " + query.Name + " was not found.");
    }
}