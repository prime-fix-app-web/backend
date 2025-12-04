using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.QueryServices;

/// <summary>
///     Query service for UserAccount aggregate
/// </summary>
/// <param name="userAccountRepository">
///     The user account repository
/// </param>
public class UserAccountQueryService(IUserAccountRepository userAccountRepository)
: IUserAccountQueryService
{
    /// <summary>
    ///     Handles the query to get all user accounts
    /// </summary>
    /// <param name="query">
    ///     The query to get all user accounts
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of user accounts.
    /// </returns>
    public async Task<IEnumerable<UserAccount>> Handle(GetAllUserAccountsQuery query)
    {
        return await userAccountRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the query to get a user account by its unique identifier
    /// </summary>
    /// <param name="query">
    ///     The query to get a user account by its unique identifier
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the user account if found; otherwise, null.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a user account with the specified identifier was not found.
    /// </exception>
    public async Task<UserAccount?> Handle(GetUserAccountByIdQuery query)
    {
        return await userAccountRepository.FindByIdAsync(query.UserAccountId)
            ?? throw new NotFoundIdException("UserAccount with the id " + query.UserAccountId + " was not found.");
    }
}