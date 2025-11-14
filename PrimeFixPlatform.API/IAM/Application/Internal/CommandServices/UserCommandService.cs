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
///     The unit of work
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
    /// <exception cref="Exception">
    ///     Indicates that a user with the same IdUser or Name and LastName already exists
    /// </exception>
    public async Task<string> Handle(CreateUserCommand command)
    {
        var idUser = command.IdUser;
        var name = command.Name;
        var lastName = command.LastName;
        
        if (await userRepository.ExistsByIdUser(idUser))
            throw new ConflictException("User with the same IdUser already exists");
        
        if (await userRepository.ExistsByNameAndLastName(name, lastName))
            throw new ConflictException("User with the same Name and LastName already exists");
        
        var user = new User(command);
        await userRepository.AddAsync(user);
        await unitOfWork.CompleteAsync();
        return user.IdUser;
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
    /// <exception cref="Exception">
    ///     Indicates that the user to update was not found or another user with the same Name and LastName already exists
    /// </exception>
    public async Task<User?> Handle(UpdateUserCommand command)
    {
        var idUser = command.IdUser;
        var name = command.Name;
        var lastName = command.LastName;
        
        if (!await userRepository.ExistsByIdUser(idUser))
            throw new NotFoundIdException("User not found");
        
        if (await userRepository.ExistsByNameAndLastNameAndIdUserIsNot(name, lastName, idUser))
            throw new ConflictException("Another user with the same Name and LastName already exists");

        var userToUpdate = await userRepository.FindByIdAsync(idUser);
        if (userToUpdate == null)
            throw new NotFoundArgumentException("User not found");
        userToUpdate.UpdateUser(command);
        userRepository.Update(userToUpdate);
        await unitOfWork.CompleteAsync();
        return userToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete an existing user
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing user
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating whether the user was deleted.
    /// </returns>
    /// <exception cref="Exception">
    ///     Indicates that the user to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeleteUserCommand command)
    {
        if (!await userRepository.ExistsByIdUser(command.IdUser))
            throw new Exception("User not found");
        var user = await userRepository.FindByIdAsync(command.IdUser);
        if (user == null)
            throw new Exception("User not found");
        userRepository.Remove(user);
        await unitOfWork.CompleteAsync();
        return true;
    }
}