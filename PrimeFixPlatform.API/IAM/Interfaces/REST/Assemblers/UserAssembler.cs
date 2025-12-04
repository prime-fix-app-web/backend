using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between User-related requests, commands, and responses.
/// </summary>
public class UserAssembler
{
    /// <summary>
    ///     Converts a CreateUserRequest to a CreateUserCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateUserRequest containing user details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateUserCommand.
    /// </returns>
    public static CreateUserCommand ToCommandFromRequest(CreateUserRequest request)
    {
        return new CreateUserCommand(
             request.Name, request.LastName,
            request.Dni, request.PhoneNumber, request.LocationId
        );
    }
    
    /// <summary>
    ///     Converts an UpdateUserRequest to an UpdateUserCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateUserRequest containing updated user details.
    /// </param>
    /// <param name="userId">
    ///     The identifier of the user to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateUserCommand.
    /// </returns>
    public static UpdateUserCommand ToCommandFromRequest(UpdateUserRequest request, int userId)
    {
        return new UpdateUserCommand(
            userId, request.Name, request.LastName,
            request.Dni, request.PhoneNumber, request.LocationId
        );
    }

    /// <summary>
    ///     Converts a User entity to a UserResponse.
    /// </summary>
    /// <param name="entity">
    ///     The User entity containing user details.
    /// </param>
    /// <returns>
    ///     The corresponding UserResponse.
    /// </returns>
    public static UserResponse ToResponseFromEntity(User entity)
    {
        return new UserResponse(
            entity.UserId, entity.Name, entity.LastName,
            entity.Dni, entity.PhoneNumber, entity.LocationId
        );
    }
}