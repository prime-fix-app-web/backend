using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Queries;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.QueryServices;

/// <summary>
///     Query service for User aggregate
/// </summary>
/// <param name="userRepository">
///     The user repository
/// </param>
public class UserQueryService(IUserRepository userRepository)
: IUserQueryService
{
    /// <summary>
    ///     Handles the query to get all users
    /// </summary>
    /// <param name="query">
    ///     The query to get all users
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     an enumerable of users.
    /// </returns>
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    /// <summary>
    ///     Handles the query to get a user by its unique identifier
    /// </summary>
    /// <param name="query">
    ///     The query to get a user by its unique identifier
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the user if found; otherwise, null.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a user with the specified identifier was not found.
    /// </exception>
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.IdUser) 
               ?? throw new NotFoundIdException("User with the id " + query.IdUser + " was not found.");
    }
}