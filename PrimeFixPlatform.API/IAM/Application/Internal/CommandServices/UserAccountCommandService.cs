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
/// <param name="userRepository">
///     The user repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class UserAccountCommandService(IUserAccountRepository userAccountRepository,
    IUserRepository userRepository,
    IMembershipRepository membershipRepository,
    IRoleRepository roleRepository,
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
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user, role, or membership with the specified ID does not exist
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that a user account with the same UserAccountId, Username or Email already exists
    /// </exception>
    public async Task<int> Handle(CreateUserAccountCommand command)
    {
        // Validate user existence
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null)
            throw new NotFoundArgumentException("User not found with the given id " + command.UserId);
        
        // Validate role existence
        var role = await roleRepository.FindByIdAsync(command.RoleId);
        if (role == null)
            throw new NotFoundArgumentException("Role not found with the given id " + command.RoleId);
        
        // Validate membership existence
        var membership = await membershipRepository.FindByIdAsync(command.MembershipId);
        if (membership == null)
            throw new NotFoundArgumentException("Membership not found with the given id " + command.MembershipId);
        
        var username = command.Username;
        var email = command.Email;
        
        // Check for existing username
        if (await userAccountRepository.ExistsByUsername(username))
            throw new ConflictException("UserAccount with the same username " + username + " already exists");
        
        // Check for existing email
        if (await userAccountRepository.ExistsByEmail(email))
            throw new ConflictException("UserAccount with the same email " + email + " already exists");
        
        var userAccount = new UserAccount(command);
        await userAccountRepository.AddAsync(userAccount);
        await unitOfWork.CompleteAsync();
        userAccount.User = user;
        userAccount.Role = role;
        userAccount.Membership = membership;
        return userAccount.Id;
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
        var userAccountId = command.UserAccountId;
        var username = command.Username;
        var email = command.Email;
        
        if (!await userAccountRepository.ExistsByUserAccountId(userAccountId)) 
            throw new NotFoundIdException("UserAccount with id " + userAccountId + " not found");
        
        if (await userAccountRepository.ExistsByUsernameAndUserAccountIdIsNot(username, userAccountId))
            throw new ConflictException("UserAccount with the same username " + username + " already exists");
        
        if (await userAccountRepository.ExistsByEmailAndUserAccountIdIsNot(email, userAccountId))
            throw new ConflictException("UserAccount with the same email " + email + " already exists");
        
        var userAccountToUpdate = await userAccountRepository.FindByIdAsync(userAccountId);
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
        if (!await userAccountRepository.ExistsByUserAccountId(command.UserAccountId)) 
            throw new NotFoundIdException("UserAccount with id " + command.UserAccountId + " not found");
        var userAccount = await userAccountRepository.FindByIdAsync(command.UserAccountId);
        if (userAccount == null)
            throw new NotFoundArgumentException("UserAccount not found");
        userAccountRepository.Remove(userAccount);
        await unitOfWork.CompleteAsync();
        return true;
    }
}