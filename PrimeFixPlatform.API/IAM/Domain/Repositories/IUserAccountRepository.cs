using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Shared.Domain.Repositories;

namespace PrimeFixPlatform.API.Iam.Domain.Repositories;

/// <summary>
///     Represents the contract for user account repository operations.
/// </summary>
public interface IUserAccountRepository : IBaseRepository<UserAccount>
{
    /// <summary>
    ///    Checks if a user account exists by its identifier.
    /// </summary>
    /// <param name="idUserAccount">
    ///     The identifier of the user account.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains true if the user account exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsByIdUserAccount(string idUserAccount);
    
    /// <summary>
    ///     Checks if a user account exists by its username.
    /// </summary>
    /// <param name="username">
    ///     The username of the user account.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains true if the user account exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsByUsername(string username);
    
    /// <summary>
    ///     Checks if a user account exists by its email.
    /// </summary>
    /// <param name="email">
    ///     The email of the user account.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains true if the user account exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsByEmail(string email);
    
    /// <summary>
    ///     Checks if a user account exists by its username excluding a specific user account ID.
    /// </summary>
    /// <param name="username">
    ///     The username of the user account.
    /// </param>
    /// <param name="idUserAccount">
    ///     The identifier of the user account to exclude.
    /// </param>
    /// <returns>
    ///    A task that represents the asynchronous operation. The task result contains true if the user account exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsByUsernameAndIdUserAccountIsNot(string username, string idUserAccount);
    
    /// <summary>
    ///     Checks if a user account exists by its email excluding a specific user account ID.
    /// </summary>
    /// <param name="email">
    ///     The email of the user account.
    /// </param>
    /// <param name="idUserAccount">
    ///     The identifier of the user account to exclude.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains true if the user account exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsByEmailAndIdUserAccountIsNot(string email, string idUserAccount);
    
    /// <summary>
    ///     Finds a user account by its username.
    /// </summary>
    /// <param name="username">
    ///     The username of the user account.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the UserAccount entity if found; otherwise, null.
    /// </returns>
    Task<UserAccount?> FindByUsername(string username);
}