using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;

namespace PrimeFixPlatform.API.Iam.Domain.Services;

/// <summary>
///     Represents the contract for role query services.
/// </summary>
public interface IRoleQueryService
{
    /// <summary>
    ///     Handles the retrieval of all roles.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving all roles.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable collection of Role entities.
    /// </returns>
    Task<IEnumerable<Role>> Handle(GetAllRolesQuery query);

    /// <summary>
    ///     Handles the retrieval of a role by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the unique identifier of the role to be retrieved.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the Role entity if found; otherwise, null.
    /// </returns>
    Task<Role?> Handle(GetRoleByIdQuery query);
}