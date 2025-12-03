using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Aggregates;
using PrimeFixPlatform.API.AutorepairCatalog.Domain.Model.Commands;
using PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Resources;

namespace PrimeFixPlatform.API.AutorepairCatalog.Interfaces.REST.Assemblers;

/// <summary>
///     Assembler for converting between Location-related requests, commands, and responses.
/// </summary>
public class LocationAssembler
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
        return new CreateLocationCommand(
            request.IdLocation, request.Address, request.District, request.Department
        );
    }
    
    /// <summary>
    ///     Converts an UpdateLocationRequest to an UpdateLocationCommand.
    /// </summary>
    /// <param name="request">
    ///     The UpdateLocationRequest containing updated location details.
    /// </param>
    /// <param name="idLocation">
    ///     The identifier of the location to be updated.
    /// </param>
    /// <returns>
    ///     The corresponding UpdateLocationCommand.
    /// </returns>
    public static UpdateLocationCommand ToCommandFromRequest(UpdateLocationRequest request, int idLocation)
    {
        return new UpdateLocationCommand(
            idLocation, request.Address, request.District, request.Department
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
            entity.IdLocation, entity.Address, entity.District, entity.Department
        );
    }
}