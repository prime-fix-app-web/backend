using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;

namespace PrimeFixPlatform.API.Iam.Domain.Services;

/// <summary>
///     Represents the contract for user query services.
/// </summary>
public interface IUserQueryService
{
    
    /// <summary>
    ///     Handles the retrieval of all users.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving all users.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains an enumerable collection of User entities.
    /// </returns>
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    
    /// <summary>
    ///     Handles the retrieval of a user by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the unique identifier of the user to be retrieved.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the User entity if found; otherwise, null.
    /// </returns>
    Task<User?> Handle(GetUserByIdQuery query);

    /// <summary>
    ///     Handles the existence check of a user by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the unique identifier of the user to check for existence.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating whether the user exists.
    /// </returns>
    Task<bool> Handle(ExistsUserByIdQuery query);
}