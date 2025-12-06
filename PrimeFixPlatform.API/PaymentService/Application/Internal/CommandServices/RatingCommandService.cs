using PrimeFixPlatform.API.PaymentService.Application.Internal.OutboundServices.ACL;
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
///     Unit of work for tha rating management
/// </param>
public class RatingCommandService(
    IRatingRepository ratingRepository, 
    IExternalIamServiceFromPaymentService externalIamServiceFromPaymentService,
    IExternalAutoRepairCatalogServiceFromPaymentService externalAutoRepairCatalogServiceFromPaymentService,
    IUnitOfWork unitOfWork)
    : IRatingCommandService
{
    
    /// <summary>
    ///     Handle the creation of a new rating.
    /// </summary>
    /// <param name="command">
    ///     The command containing rating details
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the ID of the created rating.
    /// </returns>
    /// <exception cref="ConflictException">
    ///     Indicates that a rating with the same ID already exists.
    /// </exception>
    public async Task<int> Handle(CreateRatingCommand command)
    {
        var autoRepairId = command.AutoRepairId;
        var userAccountId = command.UserAccountId;
        
        // Validate auto repair existence in Auto Repair Catalog Service
        if (!await externalAutoRepairCatalogServiceFromPaymentService.ExistsAutoRepairByIdAsync(autoRepairId))
            throw new NotFoundArgumentException("AutoRepair with id " + autoRepairId + " not found in Auto Repair Catalog Service");
        
        // Validate user account existence in IAM Service
        if (!await externalIamServiceFromPaymentService.ExistsUserAccountByIdAsync(userAccountId))
            throw new NotFoundArgumentException("UserAccount with id " + userAccountId + " not found in IAM Service");
        
        // Validate uniqueness of auto repair id
        if (await ratingRepository.ExistsByIdAutoRepair(autoRepairId))
            throw new ConflictException("Rating with the same auto repair id " + autoRepairId + " already exists");

        var rating = new Rating(command);
        await ratingRepository.AddAsync(rating);
        await unitOfWork.CompleteAsync();
        return rating.RatingId;
        
    }

    /// <summary>
    ///     Handle the update of an existing rating
    /// </summary>
    /// <param name="command">
    ///     The command containing updated notification details.
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated rating.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the rating to be updated does not exist
    /// </exception>
    /// <exception cref="ConflictException">
    ///     Indicates that the rating with the same autorepair id already exists
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the rating to be updated was not found
    /// </exception>
    public async Task<Rating?> Handle(UpdateRatingCommand command)
    {
        var ratingId = command.RatingId;
        var autoRepairId = command.AutoRepairId;
        var userAccountId = command.UserAccountId;
        
        // Validate auto repair existence in Auto Repair Catalog Service
        if (!await externalAutoRepairCatalogServiceFromPaymentService.ExistsAutoRepairByIdAsync(autoRepairId))
            throw new NotFoundArgumentException("AutoRepair with id " + autoRepairId + " not found in Auto Repair Catalog Service");
        
        // Validate user account existence in IAM Service
        if (!await externalIamServiceFromPaymentService.ExistsUserAccountByIdAsync(userAccountId))
            throw new NotFoundArgumentException("UserAccount with id " + userAccountId + " not found in IAM Service");
        
        // Validate rating existence
        if (!await ratingRepository.ExistsByIdRating(ratingId))
            throw new NotFoundIdException("Rating the same id " + ratingId  + " already exists");
        
        // Validate uniqueness of auto repair id excluding the current rating
        if (await ratingRepository.ExistsByIdAutoRepairAndIdRatingIsNot(autoRepairId, ratingId))
            throw new ConflictException("Rating with the same auto repair id " + autoRepairId  + " already exists");
        
        var ratingToUpdate = await ratingRepository.FindByIdAsync(ratingId);
        if (ratingToUpdate is null)
            throw new NotFoundArgumentException("Rating not found");
        ratingToUpdate.UpdateRating(command);
        ratingRepository.Update(ratingToUpdate);
        await unitOfWork.CompleteAsync();
        return ratingToUpdate;
        
    }
    
    /// <summary>
    ///     Handle the deletion of a rating
    /// </summary>
    /// <param name="command">
    ///     The command containing the ID of the rating to delete
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result indicates whether the deletion was successful.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that the rating to be deleted does not exist.
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the rating to be deleted was not found.
    /// </exception>
    public async Task<bool> Handle(DeleteRatingCommand command)
    {
        if (!await ratingRepository.ExistsByIdRating(command.RatingId))
            throw new NotFoundIdException("Rating with id " + command.RatingId  + " does not exist");
        var rating = await ratingRepository.FindByIdAsync(command.RatingId);
        if (rating is null)
            throw new NotFoundArgumentException("Rating not found");
        ratingRepository.Remove(rating);
        await unitOfWork.CompleteAsync();
        return true;
    }
}