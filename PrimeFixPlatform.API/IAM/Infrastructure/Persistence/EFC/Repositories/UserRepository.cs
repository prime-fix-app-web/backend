using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PrimeFixPlatform.API.Iam.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Repository for managing User entities.
/// </summary>
/// <param name="context">
///     The database context used for data access.
/// </param>
public class UserRepository(AppDbContext context)
: BaseRepository<User>(context),  IUserRepository
{
    /// <summary>
    ///     Checks if a User exists by their unique identifier.
    /// </summary>
    /// <param name="idUser">
    ///     The unique identifier of the User.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a User with the specified identifier exists.
    /// </returns>
    public async Task<bool> ExistsByIdUser(string idUser)
    {
        return await Context.Set<User>().AnyAsync(user => user.IdUser == idUser);
    }

    /// <summary>
    ///     Checks if a User exists by their name and last name.
    /// </summary>
    /// <param name="name">
    ///     The name of the User.
    /// </param>
    /// <param name="lastName">
    ///     The last name of the User.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a User with the specified name and last name exists.
    /// </returns>
    public async Task<bool> ExistsByNameAndLastName(string name, string lastName)
    {
        return await Context.Set<User>().AnyAsync(user => user.Name == name && user.LastName == lastName);
    }

    /// <summary>
    ///     Checks if a User exists by their name and last name, excluding a specific user by ID.
    /// </summary>
    /// <param name="name">
    ///     The name of the User.
    /// </param>
    /// <param name="lastName">
    ///     The last name of the User.
    /// </param>
    /// <param name="idUser">
    ///     A unique identifier of the User to exclude from the check.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains
    ///     a boolean indicating whether a User with the specified name and last name exists,
    /// </returns>
    public async Task<bool> ExistsByNameAndLastNameAndIdUserIsNot(string name, string lastName, string idUser)
    {
        return await Context.Set<User>().AnyAsync(user => user.Name == name && user.LastName == lastName && user.IdUser != idUser);
    }
}