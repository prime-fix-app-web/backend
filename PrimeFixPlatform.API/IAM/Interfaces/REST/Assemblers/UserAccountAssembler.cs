using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between UserAccount-related requests, commands, and responses.
/// </summary>
public static class UserAccountAssembler
{
    /// <summary>
    ///     Converts a CreateUserAccountRequest to a CreateUserAccountCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateUserAccountRequest containing user account details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateUserAccountCommand.
    /// </returns>
    public static CreateUserAccountCommand ToCommandFromRequest(CreateUserAccountRequest request)
    {
        return new CreateUserAccountCommand(
            request.Username, request.Email, request.RoleId,
            request.UserId, request.MembershipId,request.Password
        );
    }
    
    /// <summary>
    ///     Converts an UpdateUserAccountRequest to an UpdateUserAccountCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateUserAccountRequest containing updated user account details.
    /// </param>
    /// <param name="userAccountId">
    ///     The identifier of the user account to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateUserAccountCommand.
    /// </returns>
    public static UpdateUserAccountCommand ToCommandFromRequest(UpdateUserAccountRequest request, int userAccountId)
    {
        return new UpdateUserAccountCommand(
            userAccountId, request.Username, request.Email, request.RoleId,
            request.UserId, request.MembershipId,request.Password, request.IsNew
        );
    }
    
    /// <summary>
    ///     Converts a UserAccount entity to a UserAccountResponse.
    /// </summary>
    /// <param name="entity">
    ///     The UserAccount entity containing user account details.
    /// </param>
    /// <returns>
    ///     The corresponding UserAccountResponse.
    /// </returns>
    public static UserAccountResponse ToResponseFromEntity(UserAccount entity)
    {
        return new UserAccountResponse(
            entity.Id, entity.Username, entity.Email, entity.RoleId,
            entity.UserId, entity.MembershipId,entity.Password, entity.IsNew
        );
    }
}