using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.CommandServices;

/// <summary>
///     Command service for UserAccount aggregate
/// </summary>
/// <param name="userAccountRepository">
///     The user account repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class UserAccountCommandService(IUserAccountRepository userAccountRepository,
    IUnitOfWork unitOfWork) :  IUserAccountCommandService
{
    /// <summary>
    ///     Handles the command to create a new user account
    /// </summary>
    /// <param name="command">
    ///     The command to create a new user account
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the created user account.
    /// </returns>
    /// <exception cref="ConflictException">
    ///     Indicates that a user account with the same IdUserAccount, Username or Email already exists
    /// </exception>
    public async Task<string> Handle(CreateUserAccountCommand command)
    {
        var idUserAccount = command.IdUserAccount;
        var username = command.Username;
        var email = command.Email;
        
        if (await userAccountRepository.ExistsByIdUserAccount(idUserAccount))
            throw new ConflictException("UserAccount with the same id " + idUserAccount + " already exists");
        
        if (await userAccountRepository.ExistsByUsername(username))
            throw new ConflictException("UserAccount with the same username " + username + " already exists");
        
        if (await userAccountRepository.ExistsByEmail(email))
            throw new ConflictException("UserAccount with the same email " + email + " already exists");
        
        var userAccount = new UserAccount(command);
        await userAccountRepository.AddAsync(userAccount);
        await unitOfWork.CompleteAsync();
        return userAccount.IdUserAccount;
    }

    /// <summary>
    ///     Handles the command to update an existing user account
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing user account
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the updated user account.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the user account with the specified IdUserAccount does not exist
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that another user account with the same Username or Email already exists
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user account with the specified IdUserAccount was not found
    /// </exception>
    public async Task<UserAccount?> Handle(UpdateUserAccountCommand command)
    {
        var idUserAccount = command.IdUserAccount;
        var username = command.Username;
        var email = command.Email;
        
        if (!await userAccountRepository.ExistsByIdUserAccount(idUserAccount)) 
            throw new NotFoundIdException("UserAccount with id " + idUserAccount + " not found");
        
        if (await userAccountRepository.ExistsByUsernameAndIdUserAccountIsNot(username, idUserAccount))
            throw new ConflictException("UserAccount with the same username " + username + " already exists");
        
        if (await userAccountRepository.ExistsByEmailAndIdUserAccountIsNot(email, idUserAccount))
            throw new ConflictException("UserAccount with the same email " + email + " already exists");
        
        var userAccountToUpdate = await userAccountRepository.FindByIdAsync(idUserAccount);
        if (userAccountToUpdate == null)
            throw new NotFoundArgumentException("UserAccount not found");
        
        userAccountToUpdate.UpdateUserAccount(command);
        userAccountRepository.Update(userAccountToUpdate);
        await unitOfWork.CompleteAsync();
        return userAccountToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete a user account
    /// </summary>
    /// <param name="command">
    ///     The command to delete a user account
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating
    ///     whether the deletion was successful.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the user account with the specified IdUserAccount does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user account with the specified IdUserAccount was not found
    /// </exception>
    public async Task<bool> Handle(DeleteUserAccountCommand command)
    {
        if (!await userAccountRepository.ExistsByIdUserAccount(command.IdUserAccount)) 
            throw new NotFoundIdException("UserAccount with id " + command.IdUserAccount + " not found");
        var userAccount = await userAccountRepository.FindByIdAsync(command.IdUserAccount);
        if (userAccount == null)
            throw new NotFoundArgumentException("UserAccount not found");
        userAccountRepository.Remove(userAccount);
        await unitOfWork.CompleteAsync();
        return true;
    }
}