using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;

namespace PrimeFixPlatform.API.Iam.Domain.Services;

/// <summary>
///     Represents the contract for user command operations.
/// </summary>
public interface IUserCommandService
{
    /// <summary>
    ///     Handles the creation of a new user.
    /// </summary>
    /// <param name="command">
    ///     The command containing user creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the created User entity, or null if creation failed.
    /// </returns>
    Task<string> Handle(CreateUserCommand command);
    
    /// <summary>
    ///     Handles the update of an existing user.
    /// </summary>
    /// <param name="command">
    ///     The command containing user update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the updated User entity, or null if the user was not found.
    /// </returns>
    Task<User?> Handle(UpdateUserCommand command);
    
    /// <summary>
    ///     Handles the deletion of a user.
    /// </summary>
    /// <param name="command">
    ///     The command containing user deletion details.
    /// </param>
    Task<bool> Handle(DeleteUserCommand command);
}