using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;

namespace PrimeFixPlatform.API.IAM.Interfaces.ACL;

/// <summary>
///     Context facade for IAM operations
/// </summary>
public interface IIamContextFacade
{
    /// <summary>
    ///     Check if a user account exists by user account ID
    /// </summary>
    /// <param name="userAccountId">
    ///     The user account ID to check
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation, with a boolean indicating existence as result
    /// </returns>
    Task<bool> ExistsUserAccountById(int userAccountId);
    
    /// <summary>
    ///     Check if a user exists by user ID
    /// </summary>
    /// <param name="userId">
    ///     The user ID to check
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation, with a boolean indicating existence as result
    /// </returns>
    Task<bool> ExistsUserById(int userId);
    
    /// <summary>
    ///     Fetch role by user ID
    /// </summary>
    /// <param name="userId">
    ///     The user ID to fetch the role for
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation, with the role as result
    /// </returns>
    Task<ERole> FetchRoleByUserId(int userId);
}