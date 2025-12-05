using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing UserAccount entities.
/// </summary>
/// <param name="context">
///     The database context used for data access.
/// </param>
public class UserAccountRepository(AppDbContext context)
: BaseRepository<UserAccount>(context), IUserAccountRepository
{
    /// <summary>
    ///     Checks if a UserAccount exists by its unique identifier.
    /// </summary>
    /// <param name="userAccountId">
    ///     The unique identifier of the UserAccount.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a UserAccount with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByUserAccountId(int userAccountId)
    {
        return await Context.Set<UserAccount>()
            .Include(userAccount => userAccount.User)
            .Include(userAccount => userAccount.Role)
            .Include(userAccount => userAccount.Membership)
            .AnyAsync(userAccount => userAccount.Id == userAccountId);
    }

    /// <summary>
    ///     Checks if a UserAccount exists by its username.
    /// </summary>
    /// <param name="username">
    ///     The username of the UserAccount.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a UserAccount with the specified username exists.
    /// </returns>
    public async Task<bool> ExistsByUsername(string username)
    {
        return await Context.Set<UserAccount>()
            .Include(userAccount => userAccount.User)
            .Include(userAccount => userAccount.Role)
            .Include(userAccount => userAccount.Membership)
            .AnyAsync(userAccount => userAccount.Username == username);
    }

    /// <summary>
    ///     Checks if a UserAccount exists by its email.
    /// </summary>
    /// <param name="email">
    ///     The email of the UserAccount.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a UserAccount with the specified email exists.
    /// </returns>
    public async Task<bool> ExistsByEmail(string email)
    {
        return await Context.Set<UserAccount>()
            .Include(userAccount => userAccount.User)
            .Include(userAccount => userAccount.Role)
            .Include(userAccount => userAccount.Membership)
            .AnyAsync(userAccount => userAccount.Email == email);
    }

    /// <summary>
    ///     Checks if a UserAccount exists by its username excluding a specific user account ID.
    /// </summary>
    /// <param name="username">
    ///     The username of the UserAccount.
    /// </param>
    /// <param name="userAccountId">
    ///     The identifier of the UserAccount to exclude.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a UserAccount with the specified username exists,
    ///     excluding the UserAccount with the specified ID.
    /// </returns>
    public async Task<bool> ExistsByUsernameAndUserAccountIdIsNot(string username, int userAccountId)
    {
        return await Context.Set<UserAccount>()
            .Include(userAccount => userAccount.User)
            .Include(userAccount => userAccount.Role)
            .Include(userAccount => userAccount.Membership)
            .AnyAsync(userAccount => userAccount.Username == username && userAccount.Id != userAccountId);
    }

    /// <summary>
    ///     Checks if a UserAccount exists by its email excluding a specific user account ID.
    /// </summary>
    /// <param name="email">
    ///     The email of the UserAccount.
    /// </param>
    /// <param name="userAccountId">
    ///     The identifier of the UserAccount to exclude.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a UserAccount with the specified email exists,
    ///     excluding the UserAccount with the specified ID.
    /// </returns>
    public async Task<bool> ExistsByEmailAndUserAccountIdIsNot(string email, int userAccountId)
    {
        return await Context.Set<UserAccount>()
            .Include(userAccount => userAccount.User)
            .Include(userAccount => userAccount.Role)
            .Include(userAccount => userAccount.Membership)
            .AnyAsync(userAccount => userAccount.Email == email && userAccount.Id != userAccountId);
    }

    /// <summary>
    ///     Changes to find a UserAccount by its username.
    /// </summary>
    /// <param name="username">
    ///     The username of the UserAccount.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the UserAccount with the specified username, or null if not found.
    /// </returns>
    public async Task<UserAccount?> FetchByUsername(string username)
    {
        return await Context.Set<UserAccount>()
            .Include(userAccount => userAccount.User)
            .Include(userAccount => userAccount.Role)
            .Include(userAccount => userAccount.Membership)
            .FirstOrDefaultAsync(userAccount => userAccount.Username == username);
    }

    /// <summary>
    ///     Finds a UserAccount by its user ID.
    /// </summary>
    /// <param name="userId">
    ///     The user ID of the UserAccount.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     the UserAccount with the specified user ID, or null if not found.
    /// </returns>
    public async Task<UserAccount?> FetchByUserId(int userId)
    {
        return await Context.Set<UserAccount>()
            .Include(userAccount => userAccount.User)
            .Include(userAccount => userAccount.Role)
            .Include(userAccount => userAccount.Membership)
            .FirstOrDefaultAsync(userAccount => userAccount.UserId == userId);
    }
}