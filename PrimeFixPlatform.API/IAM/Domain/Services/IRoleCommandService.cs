using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;

namespace PrimeFixPlatform.API.Iam.Domain.Services;

/// <summary>
///     Represents a service for handling role-related commands.
/// </summary>
public interface IRoleCommandService
{
    /// <summary>
    ///     Handles the creation of a new role.
    /// </summary>
    /// <param name="command">
    ///     The command containing role creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created Role entity, or null if creation failed.
    /// </returns>
    Task<int> Handle(CreateRoleCommand command);
    
    /// <summary>
    ///     Handles the update of an existing role.
    /// </summary>
    /// <param name="command">
    ///     The command containing role update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated Role entity, or null if the role was not found.
    /// </returns>
    Task<Role?> Handle(UpdateRoleCommand command);
    
    /// <summary>
    ///     Handles the deletion of a role.
    /// </summary>
    /// <param name="command">
    ///     The command containing role deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteRoleCommand command);
}