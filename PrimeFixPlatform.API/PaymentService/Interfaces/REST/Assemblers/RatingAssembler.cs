using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.PaymentService.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Rating-related requests, commands, and responses
/// </summary>
public class RatingAssembler
{
    /// <summary>
    ///     Converts a CreateRatingRequest to a CreateRatingCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateRatingRequest containing payment details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateRatingCommand.
    /// </returns>
    public static CreateRatingCommand ToCommandFromRequest(CreateRatingRequest request)
    {
        return new CreateRatingCommand(
             request.StarRating, request.Comment, request.AutoRepairId,
            request.UserIdAccountId
        );
    }
    
    /// <summary>
    ///     Converts an UpdateRatingRequest to an UpdateRatingCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateRatingRequest containing updated rating details.
    /// </param>
    /// <param name="idRating">
    ///     The identifier of the rating to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateRatingCommand.
    /// </returns>
    public static UpdateRatingCommand ToCommandFromRequest(UpdateRatingRequest request, int idRating)
    {
        return new UpdateRatingCommand(
            idRating, request.StarRating, request.Comment, request.AutoRepairId,
            request.UserAccountId
        );
    }

    /// <summary>
    ///     Converts a Rating entity to a RatingResponse.
    /// </summary>
    /// <param name="entity">
    ///     The Rating entity containing rating details.
    /// </param>
    /// <returns>
    ///     The corresponding RatingResponse.
    /// </returns>
    public static RatingResponse ToResponseFromEntity(Rating entity)
    {
        return new RatingResponse(
            entity.RatingId, entity.StarRating, entity.Comment, entity.AutoRepairId,
            entity.UserAccountId);
    }
}