using PrimeFixPlatform.API.PaymentService.Domain.Model.Aggregates;
using PrimeFixPlatform.API.PaymentService.Domain.Model.Commands;
using PrimeFixPlatform.API.PaymentService.Domain.Repositories;
using PrimeFixPlatform.API.PaymentService.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.PaymentService.Application.Internal.CommandServices;

/// <summary>
///     Command service for Rating aggregate
/// </summary>
/// <param name="ratingRepository">
///     The rating repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class RatingCommandService(IRatingRepository ratingRepository, IUnitOfWork unitOfWork)
    : IRatingCommandService
{
    /// <summary>
    ///     Handles the command to create a Rating
    /// </summary>
    /// <param name="command">
    ///     The command to create a new rating
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created rating.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a rating with the same id already exists
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that a rating associated to an autorepair with the same id already exists
    /// </exception>
    public async Task<string> Handle(CreateRatingCommand command)
    {
        var idRating = command.IdRating;
        var idAutoRepair = command.IdAutoRepair;
        
        if (await ratingRepository.ExistsByIdRating(idRating))
            throw new NotFoundIdException("Rating the same id " + idRating  + " already exists");
        
        if (await ratingRepository.ExistsByIdAutoRepair(idAutoRepair))
            throw new ConflictException("Rating with the same auto repair id " + idAutoRepair + " already exists");

        var rating = new Rating(command);
        await ratingRepository.AddAsync(rating);
        await unitOfWork.CompleteAsync();
        return rating.IdRating;
        
    }
    
    /// <summary>
    ///     Handles the command to update an existing rating
    /// </summary>
    /// <param name="command"></param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated payment.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a rating with the specified id already exists
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that a rating associated to an autorepair with the same id already exists
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that a rating with the specified id was not found
    /// </exception>
    public async Task<Rating?> Handle(UpdateRatingCommand command)
    {
        var idRating = command.IdRating;
        var idAutoRepair = command.IdAutoRepair;
        
        if (!await ratingRepository.ExistsByIdRating(idRating))
            throw new NotFoundIdException("Rating the same id " + idRating  + " already exists");
        
        if (await ratingRepository.ExistsByIdAutoRepairAndIdRatingIsNot(idAutoRepair, idRating))
            throw new ConflictException("Rating with the same auto repair id " + idAutoRepair  + " already exists");
        
        var ratingToUpdate = await ratingRepository.FindByIdAsync(idRating);
        if (ratingToUpdate is null)
            throw new NotFoundArgumentException("Rating not found");
        ratingToUpdate.UpdateRating(command);
        ratingRepository.Update(ratingToUpdate);
        await unitOfWork.CompleteAsync();
        return ratingToUpdate;
        
    }
    
    /// <summary>
    ///     Handles the command to delete an existing rating
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing rating
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the rating was successfully deleted
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a rating with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the rating to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeleteRatingCommand command)
    {
        if (!await ratingRepository.ExistsByIdRating(command.IdRating))
            throw new NotFoundIdException("Rating with id " + command.IdRating  + " does not exist");
        var rating = await ratingRepository.FindByIdAsync(command.IdRating);
        if (rating is null)
            throw new NotFoundArgumentException("Rating not found");
        ratingRepository.Remove(rating);
        await unitOfWork.CompleteAsync();
        return true;
    }
}