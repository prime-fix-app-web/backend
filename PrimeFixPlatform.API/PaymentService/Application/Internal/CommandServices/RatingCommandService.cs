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
    public async Task<int> Handle(CreateRatingCommand command)
    {
        /*var idRating = command.IdRating;*/
        var idAutoRepair = command.AutoRepairId;
        
        /*if (await ratingRepository.ExistsByIdRating(idRating))
            throw new NotFoundIdException("Rating the same id " + idRating  + " already exists");
        */
        if (await ratingRepository.ExistsByIdAutoRepair(idAutoRepair))
            throw new ConflictException("Rating with the same auto repair id " + idAutoRepair + " already exists");

        var rating = new Rating(command);
        await ratingRepository.AddAsync(rating);
        await unitOfWork.CompleteAsync();
        return rating.RatingId;
        
    }

    public async Task<Rating?> Handle(UpdateRatingCommand command)
    {
        var idRating = command.RatingId;
        var idAutoRepair = command.AutoRepairId;
        
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