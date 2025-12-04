using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.CommandServices;

/// <summary>
///     Command service for User aggregate
/// </summary>
/// <param name="userRepository">
///     The user repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork)
: IUserCommandService
{
    /// <summary>
    ///     Handles the command to create a new user
    /// </summary>
    /// <param name="command">
    ///     The command to create a new user
    /// </param>
    /// <returns>
    ///    A task that represents the asynchronous operation. The task result contains the created user.
    /// </returns>
    /// <exception cref="ConflictException">
    ///     Indicates that a user with the same IdUser or Name and LastName already exists
    /// </exception>
    public async Task<int> Handle(CreateUserCommand command)
    {
        var name = command.Name;
        var lastName = command.LastName;
        
        if (await userRepository.ExistsByNameAndLastName(name, lastName))
            throw new ConflictException("User with the same name " + name + " and last name " + lastName + " already exists");
        
        var user = new User(command);
        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
        return user.Id;
    }

    /// <summary>
    ///     Handles the command to update an existing user
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing user
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the updated user.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the user with the specified IdUser was not found
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that another user with the same Name and LastName already exists
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user with the specified IdUser was not found
    /// </exception>
    public async Task<User?> Handle(UpdateUserCommand command)
    {
        var userId = command.UserId;
        var name = command.Name;
        var lastName = command.LastName;
        
        if (!await userRepository.ExistsByUserId(userId))
            throw new NotFoundIdException("User with id" + userId + " does not exist");
        
        if (await userRepository.ExistsByNameAndLastNameAndUserIdIsNot(name, lastName, userId))
            throw new ConflictException("Another user with the same name " + name + " and last name " + lastName + " already exists");

        var userToUpdate = await userRepository.FindByIdAsync(userId);
        if (userToUpdate == null)
            throw new NotFoundArgumentException("User not found");
        userToUpdate.UpdateUser(command);
        userRepository.Update(userToUpdate);
        await unitOfWork.CompleteAsync();
        return userToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete a user
    /// </summary>
    /// <param name="command">
    ///     The command to delete a user
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating
    ///     whether the user was successfully deleted.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the user with the specified IdUser was not found
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the user with the specified IdUser was not found
    /// </exception>
    public async Task<bool> Handle(DeleteUserCommand command)
    {
        if (!await userRepository.ExistsByUserId(command.UserId))
            throw new NotFoundIdException("User with id " + command.UserId  + " does not exist");
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null)
            throw new NotFoundArgumentException("User not found");
        userRepository.Remove(user);
        await unitOfWork.CompleteAsync();
        return true;
    }
}