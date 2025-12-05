using PrimeFixPlatform.API.IAM.Domain.Model.Aggregates;
using PrimeFixPlatform.API.IAM.Domain.Model.Commands;
using PrimeFixPlatform.API.IAM.Domain.Repositories;
using PrimeFixPlatform.API.IAM.Domain.Services;
using PrimeFixPlatform.API.Shared.Domain.Repositories;
using PrimeFixPlatform.API.Shared.Infrastructure.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.IAM.Application.Internal.CommandServices;

/// <summary>
///     Command service for Location aggregate
/// </summary>
/// <param name="locationRepository">
///     The location repository
/// </param>
/// <param name="unitOfWork">
///     Unit of work
/// </param>
public class LocationCommandService(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
: ILocationCommandService
{
    /// <summary>
    ///     Handles the command to create a new location
    /// </summary>
    /// <param name="command">
    ///     The command to create a new location
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the created location.
    /// </returns>
    /// <exception cref="ConflictException">
    ///     Indicates that a location with the same id already exists
    /// </exception>
    public async Task<int> Handle(CreateLocationCommand command)
    {
        /*var idLocation = command.IdLocation;
        
        if (await locationRepository.ExistsByIdLocation(idLocation))
            throw new ConflictException("Location with the same id " + idLocation  + " already exists");
        */
        var location = new Location(command);
        await locationRepository.AddAsync(location);
        await unitOfWork.CompleteAsync();
        return location.Id;
    }

    /// <summary>
    ///     Handles the command to update an existing location
    /// </summary>
    /// <param name="command">
    ///     The command to update an existing location
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains the updated location.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a location with the specified id does not exist
    /// </exception>
    public async Task<Location?> Handle(UpdateLocationCommand command)
    {
        var locationId = command.LocationId;
        var locationToUpdate = await locationRepository.FindByIdAsync(locationId);
        if (locationToUpdate is null)
            throw new NotFoundIdException("Location with id " + locationId  + " does not exist");
        
        locationToUpdate.UpdateLocation(command);
        locationRepository.Update(locationToUpdate);
        await unitOfWork.CompleteAsync();
        return locationToUpdate;
    }

    /// <summary>
    ///     Handles the command to delete an existing location
    /// </summary>
    /// <param name="command">
    ///     The command to delete an existing location
    /// </param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains a boolean indicating whether the deletion was successful.
    /// </returns>
    /// <exception cref="NotFoundIdException">
    ///     Indicates that a location with the specified id does not exist
    /// </exception>
    /// <exception cref="NotFoundArgumentException">
    ///     Indicates that the location to delete was not found
    /// </exception>
    public async Task<bool> Handle(DeleteLocationCommand command)
    {
        if (!await locationRepository.ExistsByLocationId(command.LocationId))
            throw new NotFoundIdException("Location with id " + command.LocationId  + " does not exist");
        var location = await locationRepository.FindByIdAsync(command.LocationId);
        if (location is null)
            throw new NotFoundArgumentException("Location not found");
        locationRepository.Remove(location);
        await unitOfWork.CompleteAsync();
        return true;
    }
}