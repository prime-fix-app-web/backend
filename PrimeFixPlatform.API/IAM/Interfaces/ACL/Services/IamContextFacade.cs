using PrimeFixPlatform.API.Iam.Domain.Model.Queries;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.IAM.Interfaces.ACL.Services;

/// <summary>
///     Context facade for IAM operations
/// </summary>
/// <param name="userAccountQueryService"></param>
/// <param name="userQueryService"></param>
public class IamContextFacade(IUserAccountQueryService userAccountQueryService, IUserQueryService userQueryService)
: IIamContextFacade
{
    /// <summary>
    ///     Checks if a UserAccount exists by its identifier
    /// </summary>
    /// <param name="userAccountId">
    ///     The identifier of the UserAccount to check
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     true if the UserAccount exists; otherwise, false.
    /// </returns>
    public Task<bool> ExistsUserAccountById(int userAccountId)
    {
        var existsUserAccountByIdQuery = new ExistsUserAccountByIdQuery(userAccountId);
        return userAccountQueryService.Handle(existsUserAccountByIdQuery);
    }

    /// <summary>
    ///     Checks if a User exists by its identifier
    /// </summary>
    /// <param name="userId">
    ///     The identifier of the User to check
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     true if the User exists; otherwise, false.
    /// </returns>
    public Task<bool> ExistsUserById(int userId)
    {
        var existsUserByIdQuery = new ExistsUserByIdQuery(userId);
        return userQueryService.Handle(existsUserByIdQuery);
    }

    /// <summary>
    ///     Converts a UserId to its corresponding Role
    /// </summary>
    /// <param name="userId">
    ///     The identifier of the User
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the <see cref="ERole" /> associated with the UserId
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Thrown when no UserAccount is found for the given UserId
    /// </exception>
    public async Task<ERole> FetchRoleByUserId(int userId)
    {
        // Fetch the UserAccount associated with the given UserId
        var getUserAccountByUserIdQuery = new GetUserAccountByUserIdQuery(userId);
        var userAccount = await userAccountQueryService.Handle(getUserAccountByUserIdQuery);
        
        if (userAccount is null)
        {
            throw new NotFoundIdException("Not found UserAccount for the given UserId");
        }

        // Return the role of the UserAccount
        return userAccount.Role.Name;
    }
}