using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;

namespace PrimeFixPlatform.API.PaymentService.Domain.Services;

/// <summary>
///     Represents a service for handling rating-related commands.
/// </summary>
public interface IRatingCommandService
{
    /// <summary>
    ///     Handles the creation of a new rating.
    /// </summary>
    /// <param name="command">
    ///     The command containing rating creation details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created Rating entity, or null if creation failed.
    /// </returns>
    Task<int> Handle(CreateRatingCommand command);
    
    /// <summary>
    ///     Handles the update of an existing rating.
    /// </summary>
    /// <param name="command">
    ///     The command containing rating update details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated Rating entity, or null if the rating was not found.
    /// </returns>
    Task<Rating?> Handle(UpdateRatingCommand command);
    
    /// <summary>
    ///     Handles the deletion of a rating.
    /// </summary>
    /// <param name="command">
    ///     The command containing rating deletion details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    Task<bool> Handle(DeleteRatingCommand command);
}