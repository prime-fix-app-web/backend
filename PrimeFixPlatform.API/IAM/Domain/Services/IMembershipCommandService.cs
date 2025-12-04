using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;

namespace PrimeFixPlatform.API.Iam.Domain.Services;

/// <summary>
///     Represents a service for handling membership-related commands.
/// </summary>
public interface IMembershipCommandService
{
    /// <summary>
    ///     Handles the creation of a new membership.
    /// </summary>
    /// <param name="command">
    ///     The command containing membership creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created Membership entity, or null if creation failed.
    /// </returns>
    Task<int> Handle(CreateMembershipCommand command);

    /// <summary>
    ///     Handles the update of an existing membership.
    /// </summary>
    /// <param name="command">
    ///     The command containing membership update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated Membership entity, or null if the membership was not found.
    /// </returns>
    Task<Membership?> Handle(UpdateMembershipCommand command);
    
    /// <summary>
    ///     Handles the deletion of a membership.
    /// </summary>
    /// <param name="command">
    ///     The command containing membership deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteMembershipCommand command);
}