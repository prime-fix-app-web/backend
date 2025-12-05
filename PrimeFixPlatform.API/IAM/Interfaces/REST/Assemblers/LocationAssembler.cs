using PrimeFixPlatform.API.IAM.Domain.Model.Aggregates;
using PrimeFixPlatform.API.IAM.Domain.Model.Commands;
using PrimeFixPlatform.API.IAM.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.IAM.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Location-related requests, commands, and responses.
/// </summary>
public static class LocationAssembler
{
    /// <summary>
    ///     Converts a CreateLocationRequest to a CreateLocationCommand.
    /// </summary>
    /// <param name="request">
    ///     The CreateLocationRequest containing location details.
    /// </param>
    /// <returns>
    ///     The corresponding CreateLocationCommand.
    /// </returns>
    public static CreateLocationCommand ToCommandFromRequest(CreateLocationRequest request)
    {
        return new CreateLocationCommand(request.Address, request.District, request.Department);
    }
    
    /// <summary>
    ///     Converts an UpdateLocationRequest to an UpdateLocationCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateLocationRequest containing updated location details.
    /// </param>
    /// <param name="locationId">
    ///     The identifier of the location to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateLocationCommand.
    /// </returns>
    public static UpdateLocationCommand ToCommandFromRequest(UpdateLocationRequest request, int locationId)
    {
        return new UpdateLocationCommand(
            locationId, request.Address, request.District, request.Department
        );
    }
    
    /// <summary>
    ///     Converts a Location entity to a LocationResponse.
    /// </summary>
    /// <param name="entity">
    ///     The Location entity containing location details.
    /// </param>
    /// <returns>
    ///     The corresponding LocationResponse.
    /// </returns>
    public static LocationResponse ToResponseFromEntity(Location entity)
    {
        return new LocationResponse(
            entity.Id, entity.Address, entity.District, entity.Department
        );
    }
}