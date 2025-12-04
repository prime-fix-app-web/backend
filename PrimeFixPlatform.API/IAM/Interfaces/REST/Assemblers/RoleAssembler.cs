using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Role-related requests, commands, and responses.
/// </summary>
public static class RoleAssembler
{
    /// <summary>
    ///     Converts a CreateRoleRequest to a CreateRoleCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateRoleRequest containing role details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateRoleCommand.
    /// </returns>
    public static CreateRoleCommand ToCommandFromRequest(CreateRoleRequest request)
    {
        return new CreateRoleCommand(
            new RoleInformation(request.Name, request.Description)
        );
    }
    
    /// <summary>
    ///     Converts an UpdateRoleRequest to an UpdateRoleCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateRoleRequest containing updated role details.
    /// </param>
    /// <param name="roleId">
    ///     The identifier of the role to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateRoleCommand.
    /// </returns>
    public static UpdateRoleCommand ToCommandFromRequest(UpdateRoleRequest request, int roleId)
    {
        return new UpdateRoleCommand(
            roleId, new RoleInformation(request.Name, request.Description)
        );
    }
    
    /// <summary>
    ///     Converts a Role entity to a RoleResponse.
    /// </summary>
    /// <param name="entity">
    ///     The Role entity containing role details.
    /// </param>
    /// <returns>
    ///     The corresponding RoleResponse.
    /// </returns>
    public static RoleResponse ToResponseFromEntity(Role entity)
    {
        return new RoleResponse(
            entity.Id, entity.RoleInformation.Name, entity.RoleInformation.Description
        );
    }
}