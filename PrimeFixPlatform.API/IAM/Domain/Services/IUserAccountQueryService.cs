using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;

namespace PrimeFixPlatform.API.Iam.Domain.Services;

/// <summary>
///     Represents the contract for user account query services.
/// </summary>
public interface IUserAccountQueryService
{
    /// <summary>
    ///     Handles the retrieval of all user accounts.
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for retrieving all user accounts.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains an enumerable collection of UserAccount entities.
    /// </returns>
    Task<IEnumerable<UserAccount>> Handle(GetAllUserAccountsQuery query);
    
    /// <summary>
    ///     Handles the retrieval of a user account by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the unique identifier of the user account to be retrieved.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the UserAccount entity if found; otherwise, null.
    /// </returns>
    Task<UserAccount?> Handle(GetUserAccountByIdQuery query);

    /// <summary>
    ///     Handles the retrieval of a user account by user id.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the user id of the user account to be retrieved.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the UserAccount entity if found; otherwise, null.
    /// </returns>
    Task<UserAccount?> Handle(GetUserAccountByUserIdQuery query);
    
    /// <summary>
    ///     Handles the existence check of a user account by its unique identifier.
    /// </summary>
    /// <param name="query">
    ///     The query object containing the unique identifier of the user account to check for existence.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains true if the user account exists; otherwise, false.
    /// </returns>
    Task<bool> Handle(ExistsUserAccountByIdQuery query);
}
