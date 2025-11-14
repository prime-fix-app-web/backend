using PrimeFixPlatform.API.Iam.Domain.Model.Aggregates;
using PrimeFixPlatform.API.Iam.Domain.Model.Commands;
using PrimeFixPlatform.API.Iam.Domain.Model.ValueObjects;
using PrimeFixPlatform.API.Iam.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.Iam.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Membership-related requests, commands, and responses.
/// </summary>
public class MembershipAssembler
{
    /// <summary>
    ///     Converts a CreateMembershipRequest to a CreateMembershipCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateMembershipRequest containing membership details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateMembershipCommand.
    /// </returns>
    public static CreateMembershipCommand ToCommandFromRequest(CreateMembershipRequest request)
    {
        return new CreateMembershipCommand(
            request.IdMembership, new MembershipDescription(request.Description), 
            request.Started, request.Over
        );
    }
    
    /// <summary>
    ///     Converts an UpdateMembershipRequest to an UpdateMembershipCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateMembershipRequest containing updated membership details.
    /// </param>
    /// <param name="idMembership">
    ///     The identifier of the membership to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateMembershipCommand.
    /// </returns>
    public static UpdateMembershipCommand ToCommandFromRequest(UpdateMembershipRequest request, string idMembership)
    {
        return new UpdateMembershipCommand(
            idMembership, new MembershipDescription(request.Description), 
            request.Started, request.Over
        );
    }
    
    /// <summary>
    ///     Converts a Membership entity to a MembershipResponse.
    /// </summary>
    /// <param name="entity">
    ///     The Membership entity containing membership details.
    /// </param>
    /// <returns>
    ///     The corresponding MembershipResponse.
    /// </returns>
    public static MembershipResponse ToResponseFromEntity(Membership entity)
    {
        return new MembershipResponse(
            entity.IdMembership, entity.MembershipDescription.Description, 
            entity.Started, entity.Over
        );
    }
}