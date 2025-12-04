using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;

namespace PrimeFixPlatform.API.Iam.Domain.Services;

/// <summary>
///     Represents the contract for user account command operations.
/// </summary>
public interface IUserAccountCommandService
{
    /// <summary>
    ///     Handles the creation of a new user account.
    /// </summary>
    /// <param name="command">
    ///     The command containing user account creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the created UserAccount ID, or null if creation failed.
    /// </returns>
    Task<int> Handle(CreateUserAccountCommand command);
    
    /// <summary>
    ///     Handles the update of an existing user account.
    /// </summary>
    /// <param name="command">
    ///     The command containing user account update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the updated UserAccount entity, or null if the user account was not found.
    /// </returns>
    Task<UserAccount?> Handle(UpdateUserAccountCommand command);
    
    /// <summary>
    ///     Handles the deletion of a user account.
    /// </summary>
    /// <param name="command">
    ///     The command containing user account deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteUserAccountCommand command);
}