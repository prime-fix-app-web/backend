using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between UserAccount-related requests, commands, and responses.
/// </summary>
public class UserAccountAssembler
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
            request.IdUserAccount,request.Username, request.Email, request.IdRole,
            request.IdUser, request.Password, request.IsNew
        );
    }
    
    /// <summary>
    ///     Converts an UpdateUserAccountRequest to an UpdateUserAccountCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateUserAccountRequest containing updated user account details.
    /// </param>
    /// <param name="idUserAccount">
    ///     The identifier of the user account to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateUserAccountCommand.
    /// </returns>
    public static UpdateUserAccountCommand ToCommandFromRequest(UpdateUserAccountRequest request, string idUserAccount)
    {
        return new UpdateUserAccountCommand(
            idUserAccount, request.Username, request.Email, request.IdRole,
            request.IdUser, request.Password, request.IsNew
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
            entity.IdUserAccount, entity.Username, entity.Email, entity.IdRole,
            entity.IdUser, entity.Password, entity.IsNew
        );
    }
}