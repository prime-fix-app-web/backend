using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.Iam.Domain.Repositories;

/// <summary>
///     Represents the repository interface for managing User entities.
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
    /// <summary>
    ///     Checks if a user exists by their unique identifier.
    /// </summary>
    /// <param name="userId">
    ///     The unique identifier of the user.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a user with the specified ID exists.
    /// </returns>
    Task<bool> ExistsByUserId(int userId);
    
    /// <summary>
    ///     Checks if a user exists by their name and last name.
    /// </summary>
    /// <param name="name">
    ///     The name of the user.
    /// </param>
    /// <param name="lastName">
    ///     The last name of the user.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a user with the specified name and last name exists.
    /// </returns>
    Task<bool> ExistsByNameAndLastName(string name, string lastName);
    
    /// <summary>
    ///     Checks if a user exists by their name and last name, excluding a specific user by their ID.
    /// </summary>
    /// <param name="name">
    ///     The name of the user.
    /// </param>
    /// <param name="lastName">
    ///     The last name of the user.
    /// </param>
    /// <param name="userId">
    ///     The unique identifier of the user to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a user with the specified name and last name exists,
    ///     excluding the user with the specified ID.
    /// </returns>
    Task<bool> ExistsByNameAndLastNameAndUserIdIsNot(string name, string lastName, int userId);
}