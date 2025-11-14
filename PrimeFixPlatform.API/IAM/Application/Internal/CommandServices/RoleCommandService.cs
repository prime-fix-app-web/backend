using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Repositories;
using PrimeFixPlatform.API.Iam.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Application.Internal.CommandServices;

/// <summary>
///     Command service for Role aggregate
/// </summary>
/// <param name="roleRepository">
///     The role repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class RoleCommandService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
: IRoleCommandService
{
    /// <summary>
    ///     Handles the command to create a new role
    /// </summary>
    /// <param name="command">
    ///     The command to create a new role
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the created role.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a role with the same IdRole already exists
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that a role with the same RoleInformation already exists
    /// </exception>
    public async Task<string> Handle(CreateRoleCommand command)
    {
        var idRole = command.IdRole;
        var roleInformation = command.RoleInformation;
        
        if (await roleRepository.ExitsByIdRole(idRole))
            throw new NotFoundIdException("Role with the same id " + idRole  + " already exists");
        
        if (await roleRepository.ExistsByRoleInformation(roleInformation))
            throw new ConflictException("Role with the same name or description already exists");
        
        var role = new Role(command);
        await roleRepository.AddAsync(role);
        await unitOfWork.CompleteAsync();
        return role.IdRole;
    }

    /// <summary>
    ///     Handles the command to update an existing role
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing role
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the updated role.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a role with the specified IdRole does not exist
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that another role with the same RoleInformation already exists
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the role to update was not found
    /// </exception>
    public async Task<Role?> Handle(UpdateRoleCommand command)
    {
        var idRole = command.IdRole;
        var roleInformation = command.RoleInformation;
        
        if (!await roleRepository.ExitsByIdRole(idRole))
            throw new NotFoundIdException("Role with id " + idRole  + " does not exist");
        
        if (await roleRepository.ExistsByRoleInformationAndIdRoleIsNot(roleInformation, idRole))
            throw new ConflictException("Another role with the same name or description already exists");

        var roleToUpdate = await roleRepository.FindByIdAsync(idRole);
        if (roleToUpdate is null)
            throw new NotFoundArgumentException("Role not found");
        roleToUpdate.UpdateRole(command);
        roleRepository.Update(roleToUpdate);
        await unitOfWork.CompleteAsync();
        return roleToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete an existing role
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing role
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains a boolean indicating
    ///     whether the deletion was successful.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a role with the specified IdRole does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the role to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeleteRoleCommand command)
    {
        if (!await roleRepository.ExitsByIdRole(command.IdRole))
            throw new NotFoundIdException("Role with id " + command.IdRole  + " does not exist");
        var role = await roleRepository.FindByIdAsync(command.IdRole);
        if (role is null)
            throw new NotFoundArgumentException("Role not found");
        roleRepository.Remove(role);
        await unitOfWork.CompleteAsync();
        return true;
    }
}